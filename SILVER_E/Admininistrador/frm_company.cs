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
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.IO;

namespace SILVER_E.Admininistrador
{
    public partial class frm_company : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        byte img = new byte();
        Metodos mtd = new Metodos();
        string usuario;
        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TX_ADDRESS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
            C_LOCAL.CheckState = CheckState.Unchecked;
            C_SERVIDOR.CheckState = CheckState.Unchecked;
            C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked;
            txt_obs.ResetText();
            TXT_RFC.ResetText();
            TXT_USERNAME.ResetText();
            TXT_PASSWORD.ResetText();

            this.pc_img.Image = null;
        }

        public static byte[] imagen_bytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        //metdo queconvierte de binario a imagen
        public static Image bytes_imagen(byte[] Imagen)
        {
            if (Imagen == null) return null;

            MemoryStream ms = new MemoryStream(Imagen);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

        public void search_img()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_OBTAIN_IMAGE_LOGO", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text;
                SqlParameter msgparam = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 100);
                msgparam.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(msgparam);
                int rowsAffected = mtd.comando.ExecuteNonQuery();
                string mensaje = "";
                if (rowsAffected > 0)
                {
                    //Convert.ToString(XtraMessageBox.Show(CType(COMANDO.Parameters("@MSG").Value, String), "SGI-TEBAEV", MessageBoxButtons.OK))
                    LBL_PHOTO.Visibility = BarItemVisibility.Always;

                    LBL_PHOTO.Caption = Convert.ToString(msgparam.Value);
                }
                else
                {
                    //Convert.ToString(XtraMessageBox.Show(CType(COMANDO.Parameters("@MSG").Value, String), "SGI-TEBAEV", MessageBoxButtons.OK))
                    LBL_PHOTO.Visibility = BarItemVisibility.Always;

                    LBL_PHOTO.Caption = Convert.ToString(msgparam.Value);
                }

                SqlDataReader lectores;
                lectores = mtd.comando.ExecuteReader();

                while (lectores.Read())
                {
                    byte[] result = (byte[])lectores.GetValue(0);
                    pc_img.Image = bytes_imagen(result);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }

        }
        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_COMPANY_VIEW", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_RESULT.Visibility = BarItemVisibility.Always;
                    LBL_RESULT.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT.Visibility = BarItemVisibility.Always;
                    LBL_RESULT.Caption = Convert.ToString(Message.Value);
                }
                mtd.adaptador = new SqlDataAdapter(mtd.comando);
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);
                DGV_DATA.DataSource = DataT;
                G_DATA.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }
        public frm_company(string usu)
        {
            usuario = usu;
            InitializeComponent();
        }

        private void frm_company_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN__PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();
        }

        private void SHOW_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = true;
            SHOW_PANEL.Enabled = false;
            HIDE_PANEL.Enabled = true;
        }

        private void HIDE_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            SHOW_PANEL.Enabled = true;
            HIDE_PANEL.Enabled = false;
        }

        private void VIEW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            VIEW_AUTOFILTER.Enabled = false;
            HIDE_AUTOFILTER.Enabled = true;
        }

        private void HIDE_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsView.ShowAutoFilterRow = false;
            VIEW_AUTOFILTER.Enabled = true;
            HIDE_AUTOFILTER.Enabled = false;
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;

            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA EMPRESA", "SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            if (TXT_RFC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL RFC DE LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //server
            if (TXT_SERVIDOR.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //DATABASE
            if (TXT_DB.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //USER
            if (TXT_USERNAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //PASSWORD
            if (TXT_PASSWORD.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            if (VALIDA == true)
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA REGISTRAR LA EMPRESA EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {

                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_COMPANY_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@COM_NAME_COMPANY", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text;
                    if (TX_ADDRESS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_ADDRESS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_ADDRESS", SqlDbType.NVarChar, 100).Value = TX_ADDRESS.Text;
                    }

                    if (TXT_RFC.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_RFC", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_RFC", SqlDbType.NVarChar, 100).Value = TXT_RFC.Text;
                    }

                    if (txt_obs.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_OBSERVATIONS", SqlDbType.NVarChar, 100).Value = txt_obs.Text;
                    }

                    mtd.comando.Parameters.Add("@COM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;

                    Image imagen = pc_img.Image;
                    mtd.comando.Parameters.AddWithValue("@COM_LOGO", imagen_bytes(imagen));

                    mtd.comando.Parameters.Add("@COM_NUMBER_COMPANY", SqlDbType.NVarChar, 50).Value = CB_NUMERO.Text;
                    mtd.comando.Parameters.Add("@COM_SERVER", SqlDbType.NVarChar, 50).Value = TXT_SERVIDOR.Text;
                    mtd.comando.Parameters.Add("@COM_DB", SqlDbType.NVarChar, 50).Value = TXT_DB.Text;
                    mtd.comando.Parameters.Add("@COM_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text;
                    mtd.comando.Parameters.Add("@COM_PASSWORD", SqlDbType.NVarChar, 50).Value = TXT_PASSWORD.Text;

                    if (C_SERVIDOR.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_SERVER", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_SERVER", SqlDbType.Int).Value = C_SERVIDOR.CheckState;
                    }

                    if (C_SERVIDOR_SUCURSAL.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_SERVER_SUC", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_SERVER_SUC", SqlDbType.Int).Value = C_SERVIDOR_SUCURSAL.CheckState;
                    }

                    if (C_LOCAL.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_LOCAL", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_LOCAL", SqlDbType.Int).Value = C_LOCAL.CheckState;
                    }

                    mtd.comando.Parameters.Add("@COM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    Message.Direction = ParameterDirection.Output;
                    mtd.comando.Parameters.Add(Message);
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    if (mtd.Rows > 0)
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    mtd.DesconectarBaseDatos();
                    CLEAN_FIELDS();
                    FILL_DATA();
                }
            }

        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;
            if (TXT_ID.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA EMPRESA", "SISTEMAS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            if (TXT_RFC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL RFC DE LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //SERVER
            if (TXT_SERVIDOR.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //DATABASE
            if (TXT_DB.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            //USER
            if (TXT_USERNAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL USUARIO DE LA BASE DE DATOS ASIGNADO A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            //PASSWORD
            if (TXT_PASSWORD.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CONTRASEÑA DE LA BASE DE DATOS ASIGNADA A LA EMPRESA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (VALIDA == true)
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_COMPANY_EDIT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text;
                    mtd.comando.Parameters.Add("@COM_NAME_COMPANY", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text;
                    if (TX_ADDRESS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_ADDRESS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_ADDRESS", SqlDbType.NVarChar, 100).Value = TX_ADDRESS.Text;
                    }

                    if (TXT_RFC.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_RFC", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_RFC", SqlDbType.NVarChar, 100).Value = TXT_RFC.Text;
                    }


                    if (txt_obs.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_OBSERVATIONS", SqlDbType.NVarChar, 100).Value = txt_obs.Text;
                    }

                    mtd.comando.Parameters.Add("@COM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;


                    Image imagen = pc_img.Image;
                    mtd.comando.Parameters.AddWithValue("@COM_LOGO", imagen_bytes(imagen));


                    mtd.comando.Parameters.Add("@COM_NUMBER_COMPANY", SqlDbType.NVarChar, 50).Value = CB_NUMERO.Text;
                    mtd.comando.Parameters.Add("@COM_SERVER", SqlDbType.NVarChar, 50).Value = TXT_SERVIDOR.Text;
                    mtd.comando.Parameters.Add("@COM_DB", SqlDbType.NVarChar, 50).Value = TXT_DB.Text;
                    mtd.comando.Parameters.Add("@COM_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text;
                    mtd.comando.Parameters.Add("@COM_PASSWORD", SqlDbType.NVarChar, 50).Value = TXT_PASSWORD.Text;

                    if (C_SERVIDOR.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_SERVER", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_SERVER", SqlDbType.Int).Value = C_SERVIDOR.CheckState;
                    }

                    if (C_SERVIDOR_SUCURSAL.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_SERVER_SUC", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_SERVER_SUC", SqlDbType.Int).Value = C_SERVIDOR_SUCURSAL.CheckState;
                    }

                    if (C_LOCAL.CheckState == CheckState.Unchecked)
                    {
                        mtd.comando.Parameters.AddWithValue("@COM_IS_LOCAL", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@COM_IS_LOCAL", SqlDbType.Int).Value = C_LOCAL.CheckState;
                    }
                    mtd.comando.Parameters.Add("@COM_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    Message.Direction = ParameterDirection.Output;
                    mtd.comando.Parameters.Add(Message);
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    if (mtd.Rows > 0)
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    mtd.DesconectarBaseDatos();
                    CLEAN_FIELDS();
                    FILL_DATA();
                }
            }
        }

        private void TXT_ID_TextChanged(object sender, EventArgs e)
        {
            if (TXT_ID.Text == "")
            {
                BTN_DELETE.Enabled = false;
                BTN_EDIT.Enabled = false;
                BTN_SAVE.Enabled = true;
            }
            else
            {
                BTN_EDIT.Enabled = true;
                BTN_DELETE.Enabled = true;
                BTN_SAVE.Enabled = false;
                search_img();
            }
        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE COMPAÑIA"));


                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DIRECCION") == DBNull.Value)
                {
                    TX_ADDRESS.Text = "";
                }
                else
                {
                    TX_ADDRESS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DIRECCION"));

                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "RFC") == DBNull.Value)
                {
                    TXT_RFC.Text = "";
                }
                else
                {
                    TXT_RFC.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "RFC"));

                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value)
                {
                    txt_obs.Text = "";
                }
                else
                {
                    txt_obs.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }
                //NUMERO DE COMPAÑIA
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO COMPAÑIA") == DBNull.Value)
                {
                    CB_NUMERO.Text = "";
                }
                else
                {
                    CB_NUMERO.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO COMPAÑIA"));
                }
                //SERVIDOR
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERVIDOR") == DBNull.Value)
                {
                    TXT_SERVIDOR.Text = "";
                }
                else
                {
                    TXT_SERVIDOR.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERVIDOR"));
                }
                //BASE DE DATOS
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "BASE DATOS") == DBNull.Value)
                {
                    TXT_DB.Text = "";
                }
                else
                {
                    TXT_DB.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "BASE DATOS"));
                }
                //USUARIO
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO") == DBNull.Value)
                {
                    TXT_USERNAME.Text = "";
                }
                else
                {
                    TXT_USERNAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO"));
                }
                //PASSWORD
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA") == DBNull.Value)
                {
                    TXT_PASSWORD.Text = "";
                }
                else
                {
                    TXT_PASSWORD.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA"));
                }
                //ES SERVIDOR
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SERVIDOR") == DBNull.Value)
                {
                    C_SERVIDOR.CheckState = CheckState.Unchecked;
                }
                else
                {
                    C_SERVIDOR.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SERVIDOR");
                }
                //ES SUCURSAL
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SUCURSAL") == DBNull.Value)
                {
                    C_SERVIDOR_SUCURSAL.CheckState = CheckState.Unchecked;
                }
                else
                {
                    C_SERVIDOR_SUCURSAL.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES SUCURSAL");
                }
                //ES LOCAL
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES LOCAL") == DBNull.Value)
                {
                    C_LOCAL.CheckState = CheckState.Unchecked;
                }
                else
                {
                    C_LOCAL.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ES LOCAL");
                }


                C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //declaramos un cuadro de dialogo referenciado por openfilediaog1
            DialogResult result = new DialogResult(); //el resultado del cuadro que declaramos


            openFileDialog1.InitialDirectory = "Bibliotecas\\Imágenes\\Imagenes públicas\\Imagenes de muestra"; //damos el directorio inicial es donde buscara primero
            openFileDialog1.Filter = "archivos de imagen (*.jpg)|*.png|All files (*.*)|*.*"; //le damos 
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;
            result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                pc_img.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_LOCAL_CONNECTION_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;
            //SERVER STRING
            if (TXT_SERVIDOR.Text.Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL SERVIDOR A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VALIDA = true;
                return;
            }
            //DABATASE STRING
            if (TXT_DB.Text.Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VALIDA = true;
                return;
            }
            //USERNAME STRING
            if (TXT_USERNAME.Text.Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE USUARIO DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VALIDA = true;
                return;
            }
            //PASSWORD STRING
            if (TXT_PASSWORD.Text.Trim() == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE USUARIO DE LA BASE DE DATOS A CONFIGURAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                VALIDA = true;
                return;
            }

            //EXPORT DATA TO COMBOBOX
            if (VALIDA == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frn_main_form menu = new frn_main_form(usuario);
                menu.datosServer(TXT_SERVIDOR.Text, TXT_DB.Text, TXT_USERNAME.Text, TXT_PASSWORD.Text);

                //menu.LBL_SERVER.Caption = TXT_SERVIDOR.Text;
                //menu.LBL_DATABASE.Caption = TXT_DB.Text;
                //menu.LBL_USER_DB.Caption = TXT_USERNAME.Text;
                //menu.LB_PASSWORD.Caption = TXT_PASSWORD.Text;
                XtraMessageBox.Show("AHORA PUEDE CONFIGURAR LA EMPRESA SERVIDOR-LOCAL Y EMPRESA SERVIDOR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}