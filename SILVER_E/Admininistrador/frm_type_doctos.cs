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

namespace SILVER_E.Admininistrador
{
    public partial class frm_type_doctos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string usuario;
        Metodos mtd = new Metodos();
        public frm_type_doctos(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        public void FILL_DATA()
        {

            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_TYPE_DOCTOS_VIEW", mtd.conexion);
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

        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
        }
        private void frm_type_doctos_Load(object sender, EventArgs e)
        {

            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL TIPO DE DOCUMENTO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_TYPE_DOCTOS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@TY_NAME_TYPE_DOCTO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;

                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@TY_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@TY_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }

                    mtd.comando.Parameters.Add("@TY_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    mtd.comando.Parameters.Add("@TY_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    Message.Direction = ParameterDirection.Output;
                    mtd.comando.Parameters.Add(Message);
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
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
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL TIPO DE DOCUMENTO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL TIPO DE DOCUMENTO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {

                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_TYPE_DOCTOS_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = TXT_ID.Text;
                        mtd.comando.Parameters.Add("@TY_NAME_TYPE_DOCTO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;

                        if (TXT_OBSERVATIONS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@TY_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@TY_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                        }

                        mtd.comando.Parameters.Add("@TY_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        mtd.comando.Parameters.Add("@TY_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

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
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;
            if (TXT_ID.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL TIPO DE DOCUMENTO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_TYPE_DOCTOS_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = TXT_ID.Text;

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

            }
        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try {

                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE TIPO DOCUMENTO"));

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value) {
                    TXT_OBSERVATIONS.Text = "";
                }
                else {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));

           }
                C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");


            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BTN_CLEAN_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLEAN_FIELDS();
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();

        }

        private void BTN_PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();

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
    }
}