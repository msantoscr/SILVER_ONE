using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace SILVER_E
{
    public partial class frn_main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        frm_acceso acceso = new frm_acceso();
        Metodos mtd = new Metodos();
        string usuario = "";

        string server = "";
        string dbase = "";
        string userdb = "";
        string passw = "";
        public frn_main_form(string  usu)
        {
            InitializeComponent();
            usuario = usu;
        }


        public void datosServer(string servidor, string db, string user, string pass)
        {

            if (servidor != null && db != null && user != null && pass != null)

            {
                server = servidor.ToString();
                dbase = db.ToString();
                userdb = user.ToString();
                passw = pass.ToString();

                this.LBL_SERVER.Caption = server;
                this.LBL_DATABASE.Caption = dbase;
                LBL_USER_DB.Caption = userdb;
                this.LB_PASSWORD.Caption = passw;
            }
        }
        private void BTN_EXIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE VERIFICA SI REALMENTE DESEA SALIR O NO
            if (XtraMessageBox.Show("DESEA SALIR DEL SISTEMAS", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            else {
                this.Close();
                frm_acceso frnAccess = new frm_acceso();
                frnAccess.Show();
            }
        }

        private void BTN_COUNTRY_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO PAISES
            Admininistrador.frm_country FRMC = new Admininistrador.frm_country(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMC.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMC.Show();
        }

        private void BTN_STATES_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO ESTADOS
            Admininistrador.frm_state FRMS = new Admininistrador.frm_state(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMS.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMS.Show();
        }

        private void BTN_CITY_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO CIUDADES
            Admininistrador.frm_city FRMCITY = new Admininistrador.frm_city(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMCITY.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMCITY.Show();
        }

        private void BTN_USER_TYPE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO TIPOS DE USUARIO
            Admininistrador.frm_user_type FRMTU = new Admininistrador.frm_user_type(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMTU.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMTU.Show();
        }

        private void BTN_USERS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO USUARIO
            Admininistrador.frm_users FRMU = new Admininistrador.frm_users(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMU.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMU.Show();
        }

        private void BTN_STATUS_C_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO STATUS CLIENTES
            Admininistrador.frm_status_clients FRMSC = new Admininistrador.frm_status_clients(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMSC.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMSC.Show();
        }

        private void BTN_CLIENTS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO CLIENTES
            Admininistrador.frm_clients FRMC = new Admininistrador.frm_clients(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMC.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMC.Show();
        }

        private void BTN_TYPE_DOCTO_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO TIPOS DOCUMENTOS
            Admininistrador.frm_type_doctos FRMTDC = new Admininistrador.frm_type_doctos(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMTDC.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMTDC.Show();
        }

        private void BTN_FOLIOS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO FOLIOS
            Admininistrador.frm_folios FRMF = new Admininistrador.frm_folios(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMF.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMF.Show();
        }

        private void BTN_ROUTE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO RUTAS
            Admininistrador.frm_route FRMR = new Admininistrador.frm_route(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMR.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMR.Show();
        }

        private void BTN_AGENTS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO AGENTES
            Admininistrador.frm_agents FRMA = new Admininistrador.frm_agents(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMA.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMA.Show();
        }

        private void BTN_COMPANY_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO COMPANY
            Admininistrador.frm_company FRMCOMPANY = new Admininistrador.frm_company(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMCOMPANY.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMCOMPANY.Show();
        }

        private void BTN_WAREHOUSE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO ALMACENES
            Admininistrador.frm_warehouse FRMCOMPANY = new Admininistrador.frm_warehouse(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMCOMPANY.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMCOMPANY.Show();
        }

        private void BTN_MATERIALES_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO MATERIAL
            Admininistrador.frm_material FRMMAT = new Admininistrador.frm_material(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMMAT.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMMAT.Show();
        }

        private void BTN_ACCESORIOS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO ACCESORIOS
            Admininistrador.frm_accessories FRMacc = new Admininistrador.frm_accessories(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMacc.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMacc.Show();
        }

        private void BTN_ARTICLES_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO articulos
            Admininistrador.frm_assign_acc_mat FRMART = new Admininistrador.frm_assign_acc_mat(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMART.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMART.Show();
        }

        private void BTN_PROVEEDORES_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO PROVEEDORES
            Admininistrador.frm_providers FRMPROV = new Admininistrador.frm_providers(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMPROV.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMPROV.Show();
        }

        private void BTN_COMPRAS_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO COMPRAS
            Admininistrador.frm_compras FRMCOMP = new Admininistrador.frm_compras(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMCOMP.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMCOMP.Show();
        }

        private void BTN_EXCEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO EXCEL
            TOOLS.frm_excel FRMEXCEL = new TOOLS.frm_excel();
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMEXCEL.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMEXCEL.Show();
        }

        private void BTN_PDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO pdf
            TOOLS.frm_pdf DRMPDF = new TOOLS.frm_pdf();
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            DRMPDF.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            DRMPDF.Show();
        }

        private void BTN_WORD_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO word
            TOOLS.frm_word FRMWORD = new TOOLS.frm_word();
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMWORD.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMWORD.Show();
        }

        private void frn_main_form_Load(object sender, EventArgs e)
        {
            
            LBL_USERNAME.Caption = usuario.ToUpper(); //LE ASIGNAMOS A LA ETIQUETA EL NOMBRE DE USUARIO CON EL CUAL INICIAMOS SESION EN EL SISTEMA
         //ASIGNAMOS A LA ETIQUETA EL NOMBRE DEL SERVIDOR (DATASOURCE) EN EL CUAL ESTAMOS CONECTADOS ACTUALMENTE
            LBL_SERVER.Caption = mtd.conexion.DataSource.ToString();
            //ASIGNAMOS A LA ETIQUETA EL NOMBRE DE LA BASE DE DATOS (DATABASE) A LA CUAL ESTAMOS CONECTADOS
            LBL_DATABASE.Caption = mtd.conexion.Database.ToString();
           
        }

        private void BTN_PUNTOVTA_ItemClick(object sender, ItemClickEventArgs e)
        {
            //INSTANCIAMOS AL FORMULARIO PUNTO DE VENTA
            Admininistrador.frm_ptovta FRMCOMP = new Admininistrador.frm_ptovta(usuario);
            //ASIGNAMOS EL PADRE DEL FORMULARIO
            FRMCOMP.MdiParent = this;
            //MOSTRAMOS EL FORMULARIO
            FRMCOMP.Show();
        }

        private void BT_COBRANZA_ItemClick(object sender, ItemClickEventArgs e)
        {
            Admininistrador.frm_cobranza frncobranza = new Admininistrador.frm_cobranza(usuario);
            frncobranza.MdiParent = this;
            frncobranza.Show();
        }
    }
}