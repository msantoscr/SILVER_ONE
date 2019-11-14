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
    public partial class frm_folios : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        public frm_folios(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }
        #region "METODOS"
        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
        }

        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_FOLIOS_VIEW", mtd.conexion);
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

        public void LIST_TYPE_DOCTO()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_LIST_TYPE_DOCTOS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //.Parameters.Add("@ID_EMPLOYEE", SqlDbType.Int).Value = TXT_ID.Text.Trim
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);
                CB_TYPE_DOCTO.DataSource = DataT;
                CB_TYPE_DOCTO.ValueMember = "ID_FOLIOS_DOCTOS";
                CB_TYPE_DOCTO.DisplayMember = "TY_NAME_TYPE_DOCTO";
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

        public void LIST_VALUE_TYPE_DOCTO()
        {

            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_VALUE_FOLIOS_TYPE_DOCTOS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text.Trim();
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_FOLIO.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_FOLIO.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);

                CB_TYPE_DOCTO.DataSource = DataT;
                CB_TYPE_DOCTO.ValueMember = "ID_FOLIOS_DOCTOS";
                CB_TYPE_DOCTO.DisplayMember = "TY_NAME_TYPE_DOCTO";

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

        #endregion
        private void frm_folios_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL FOLIO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_FOLIOS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    // .Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = CB_TYPE_DOCTO.SelectedValue
                    mtd.comando.Parameters.Add("@FO_NAME_SERIE_FOLIO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;

                    mtd.comando.Parameters.Add("@FO_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    mtd.comando.Parameters.Add("@FO_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

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

        private void BTN_REFRESH_TYPE_DOC_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_TYPE_DOCTO();
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
                XtraMessageBox.Show("DEBE ESPECIFICAR LA SERIE DEL FOLIO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL FOLIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_FOLIOS_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text;
                        mtd.comando.Parameters.Add("@ID_FOLIOS_DOCTOS", SqlDbType.Int).Value = CB_TYPE_DOCTO.SelectedValue;
                        mtd.comando.Parameters.Add("@FO_NAME_SERIE_FOLIO", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;

                        if (TXT_OBSERVATIONS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@FO_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@FO_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                        }
                        mtd.comando.Parameters.Add("@FO_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        mtd.comando.Parameters.Add("@FO_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

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
                LIST_VALUE_TYPE_DOCTO();
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
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL ESTADO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;

                }
                else
                {
                    try
                    {

                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_FOLIOS_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = TXT_ID.Text;

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

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SERIE FOLIO"));

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value)
                {
                    TXT_OBSERVATIONS.Text = "";
                }
                else
                {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }
                C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");

            }
            catch (Exception ex)
            {
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

        private void SHOW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            G_DATA.OptionsView.ShowAutoFilterRow = true;
            SHOW_AUTOFILTER.Enabled = false;
            HIDE_AUTOFILTER.Enabled = true;
        }

        private void HIDE_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsView.ShowAutoFilterRow = false;
            SHOW_AUTOFILTER.Enabled = true;
            HIDE_AUTOFILTER.Enabled = false;
        }

        private void CB_TYPE_DOCTO_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CB_TYPE_DOCTO.Text == "P")
            {
                TXT_OBSERVATIONS.Text = "SERIE DE CONSIGNACION";
            }
            else if (CB_TYPE_DOCTO.Text == "D")
            {
                TXT_OBSERVATIONS.Text = "SERIE DEVOLUCION";
            }
            else if (CB_TYPE_DOCTO.Text == "R")
            {
                TXT_OBSERVATIONS.Text = "SERIE REMISION";
            }
            else if (CB_TYPE_DOCTO.Text == "C")
            {
                TXT_OBSERVATIONS.Text = "SERIE CLIENTE";
            }
            else if (CB_TYPE_DOCTO.Text == "G")
            {
                TXT_OBSERVATIONS.Text = "SERIE GARANTIA";
            }
        }
    }
}