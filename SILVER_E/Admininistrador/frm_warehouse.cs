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
    public partial class frm_warehouse : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;

        public frm_warehouse(string usu)
        {
            usuario = usu;
            InitializeComponent();
        }

        public void LIST_COMPANY()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_LIST_COMPANY_LOGIN", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);

                CB_COMPANY.DataSource = DataT;
                CB_COMPANY.ValueMember = "ID_COMPANY";
                CB_COMPANY.DisplayMember = "COM_NAME_COMPANY";
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

        public void LIST_VALUE_AGENTS()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_VALUE_AGENTS_WAREHOUSE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@ID_AGENT", SqlDbType.Int).Value = TXT_ID.Text.Trim();
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);

                CB_AGENTS.DataSource = DataT;
                CB_AGENTS.ValueMember = "ID_AGENTS";
                CB_AGENTS.DisplayMember = "AG_NAME_AGENT";
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
        public void LIST_VALUE_COMPANY()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_VALUE_COMPANY_WAREHOUSE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = TXT_ID.Text.Trim();
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_RESULT_COMPANY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COMPANY.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);

                CB_COMPANY.DataSource = DataT;
                CB_COMPANY.ValueMember = "ID_COMPANY";
                CB_COMPANY.DisplayMember = "COM_NAME_COMPANY";

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
                mtd.comando = new SqlCommand("SP_SILV_WAREHOUSE_VIEW", mtd.conexion);
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

        public void LIST_AGENTS()
        {

            try
            {

                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_LIST_AGENTS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_AGENTS.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_AGENTS.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_AGENTS.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_AGENTS.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);

                CB_AGENTS.DataSource = DataT;
                CB_AGENTS.ValueMember = "ID_AGENTS";
                CB_AGENTS.DisplayMember = "AG_NAME_AGENT";


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
            CB_NUMERO.ResetText();
        }

        private void frm_warehouse_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;

            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ALMACEN", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_WAREHOUSE_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue;
                    mtd.comando.Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_AGENTS.SelectedValue;
                    mtd.comando.Parameters.Add("@ALM_NUMBER_WAREHOUSE", SqlDbType.NVarChar, 10).Value = CB_NUMERO.Text;
                    mtd.comando.Parameters.Add("@ALM_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;


                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@ALM_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@ALM_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }
                    mtd.comando.Parameters.Add("@ALM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    mtd.comando.Parameters.Add("@ALM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

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
                    FILL_DATA();
                }
            }
        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "IDENTIFICADOR"));
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE ALMACEN"));

                CB_NUMERO.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NUMERO ALMACEN"));


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
                LIST_VALUE_COMPANY();
                LIST_VALUE_AGENTS();
            }
        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool valida = false;
            if (TXT_ID.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (CB_NUMERO.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NUMERO DE ALMACEN PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (valida == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR INGRESAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DEL ALMACEN?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_WAREHOUSE_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_WAREHOUSE", SqlDbType.Int).Value = TXT_ID.Text;
                        mtd.comando.Parameters.Add("@ID_COMPANY", SqlDbType.Int).Value = CB_COMPANY.SelectedValue;
                        mtd.comando.Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_AGENTS.SelectedValue;

                        mtd.comando.Parameters.Add("@ALM_NUMBER_WAREHOUSE", SqlDbType.NVarChar, 10).Value = CB_NUMERO.Text;
                        mtd.comando.Parameters.Add("@ALM_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;


                        if (TXT_OBSERVATIONS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@ALM_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@ALM_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                        }
                        mtd.comando.Parameters.Add("@ALM_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        mtd.comando.Parameters.Add("@ALM_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

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
                        FILL_DATA();
                    }
                }
            }
        }

        private void BTN_CLEAN_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLEAN_FIELDS();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void REFRESH_COMPANY_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_COMPANY();
        }

        private void REFRESH_AGENTS_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_AGENTS();
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();
        }

        private void BTN_PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();
        }

        private void PANEL_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = true;
            PANEL_SHOW.Enabled = false;
            HIDE_PANEL.Enabled = true;
        }

        private void HIDE_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            PANEL_SHOW.Enabled = true;
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

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool valida = false;
            if (TXT_ID.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (valida == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR INGRESAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA ELIMINAR LA INFORMACION DEL ALMACEN?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_WAREHOUSE_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_WAREHOUSE", SqlDbType.Int).Value = TXT_ID.Text;


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
                        FILL_DATA();
                    }
                }
            }
        }
    }
}