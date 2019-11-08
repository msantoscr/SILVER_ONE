using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SILVER_E
{
    public partial class frm_acceso : Form
    {
        Metodos mtd = new Metodos();

        ServiceReference1.WebService1SoapClient WSDatos = new SILVER_E.ServiceReference1.WebService1SoapClient();
        DataSet objEmpresa = new DataSet();

        public frm_acceso()
        {
            InitializeComponent();
        }

        private void btn_access_Click(object sender, EventArgs e)
        {
            bool VALIDA = false;

            if (txt_username.Text.ToString().Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                txt_username.Focus();
            }

            if (txt_password.Text.ToString().Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DEL USUARIO", "SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                txt_password.Focus();
            }
            //SE ANEXA CODIGO PARA VALIDACION DE USUARIO Y CONTRASEÑA MAESTRA QUE SE ENCUENTRA DECLARADA EN EL MODULO MetodosClases
            //SI EL TEXTO DE LAS CAJAS DE TEXTO COINCIDE CON EL USUARIO Y CONTRASEÑA MAESTRA ENTONCES
            if (txt_username.Text == mtd.Username && txt_password.Text == mtd.Password)
            {
                this.Hide();
                //MOSTRAMOS EL FORMULARIO PRINCIPAL DEL SISTEMA
                frn_main_form frnMenu = new frn_main_form(txt_username.Text);
                frnMenu.Show();
                txt_password.ResetText();
                txt_username.ResetText();
            }
            else //EN CASO CONTRARIO QUE NO COINCIDA EL TEXTO
            {
                if (VALIDA == true)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        if (mtd.UsuarioRegistrado(txt_username.Text.ToString().Trim()) == true)
                        {
                            string contra = mtd.ExisteContrasena(txt_username.Text.ToString().Trim());

                            if (contra.Equals(txt_password.Text) == true)
                            {
                                this.Hide();
                                if (mtd.ConsultaTipoUsuario(txt_username.Text.ToString().Trim()) == 1)
                                {
                                    frn_main_form frnMenu = new frn_main_form(txt_username.Text);
                                    frnMenu.Show();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("CONTRASEÑA INVALIDA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_username.Focus();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("EL USUARIO:--" + txt_username.Text + "--NO SE ENCUENTRA REGISTRADO O SU CUENTA ESTA DESACTIVADA");
                            // SE ASIGNA EL FOCO A TXT_USERNAME 
                            txt_username.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        mtd.DesconectarBaseDatos();
                        txt_password.ResetText();
                        txt_username.ResetText();

                        txt_username.Focus();
                    }
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("¿DESEA SALIR COMPLETAMENTE DEL SISTEMA?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void frm_acceso_Load(object sender, EventArgs e)
        {
            if (mtd.VerificaInstancia() == false)
            {
                CheckForIllegalCrossThreadCalls = false;
                DataSet ds_instancia = new DataSet();
                string mac = mtd.ObtenerMac();
                string mac2 = mac.Replace("-", "");
                int resultadoInsertado = 0;
                ds_instancia = WSDatos.ObtenerInstancia(mac2);
                resultadoInsertado = mtd.InsertarInstanciaLocal(ds_instancia);
                if (resultadoInsertado == 3)
                {
                    objEmpresa = mtd.GetDatosEmpresa();
                    foreach (DataRow dr in objEmpresa.Tables[0].Rows)
                    {


                        cboEmpresa.Items.Add(dr[0].ToString());

                    }
                }
                else
                {
                    XtraMessageBox.Show("OCURRIO UN ERROR AL INSERTAR EL REGISTRO EN LA BD LOCAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else {
                objEmpresa = mtd.GetDatosEmpresa();
                foreach (DataRow dr in objEmpresa.Tables[0].Rows)
                {


                    cboEmpresa.Items.Add(dr[0].ToString());

                }
            }
        }
    }
}
