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
    public partial class frm_assign_acc_mat : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        public frm_assign_acc_mat(string usu)
        {
            usuario = usu;
            InitializeComponent();
        }

        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_PRODUCTS_DATA_VIEW", mtd.conexion);
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
            TXT_ACC.ResetText();
            TXT_DESC_ACC.ResetText();
            TXT_MAT.ResetText();
            TXT_LINE.ResetText();
            TXT_DESC_MAT.ResetText();
            TXT_ACC.Focus();
        }



        private void frm_assign_acc_mat_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool valida = false;

            if (TXT_ACC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_DESC_ACC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (TXT_DESC_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_LINE.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DEL PRODUCTO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (valida == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR AGREGAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_PRODUCTS_DATA_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@PRD_ACC_NAME", SqlDbType.NVarChar, 50).Value = TXT_ACC.Text;
                    mtd.comando.Parameters.Add("@PRD_MAT_NAME", SqlDbType.NVarChar, 50).Value = TXT_MAT.Text;
                    mtd.comando.Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 50).Value = TXT_LINE.Text;
                    mtd.comando.Parameters.Add("@PRD_NAME_ACC_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_ACC.Text;
                    mtd.comando.Parameters.Add("@PRD_NAME_MAT_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_MAT.Text;

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

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_CLEAN_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLEAN_FIELDS();
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

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TXT_ACC.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACCESORIO"));
                TXT_DESC_ACC.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DESCRIPCION ACCESORIO"));
                TXT_MAT.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "MATERIAL"));
                TXT_DESC_MAT.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "DESCRIPCION MATERIAL"));

                TXT_LINE.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "LINEA"));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (TXT_ACC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (TXT_DESC_ACC.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL ACCESORIO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (TXT_DESC_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DEL MATERIAL", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_LINE.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DEL PRODUCTO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (valida == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DEL PRODUCTO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_PRODUCTS_DATA_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_PRODUCTS_DATA", SqlDbType.Int).Value = TXT_ID.Text;
                        mtd.comando.Parameters.Add("@PRD_ACC_NAME", SqlDbType.NVarChar, 50).Value = TXT_ACC.Text;
                        mtd.comando.Parameters.Add("@PRD_MAT_NAME", SqlDbType.NVarChar, 50).Value = TXT_MAT.Text;
                        mtd.comando.Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 50).Value = TXT_LINE.Text;
                        mtd.comando.Parameters.Add("@PRD_NAME_ACC_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_ACC.Text;
                        mtd.comando.Parameters.Add("@PRD_NAME_MAT_DESC", SqlDbType.NVarChar, 100).Value = TXT_DESC_MAT.Text;

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
            bool valida = false;
            if (TXT_ID.Text == "") {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (valida == true) {
                return;
           }
            else {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_PRODUCTS_DATA_DELETE", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@ID_PRODUCTS_DATA", SqlDbType.Int).Value = TXT_ID.Text;
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
                finally {
                    mtd.DesconectarBaseDatos();
                    CLEAN_FIELDS();
                    FILL_DATA();
                }
            }
        }

        private void TXT_MAT_TextChanged(object sender, EventArgs e)
        {
            TXT_LINE.Text = TXT_ACC.Text + TXT_MAT.Text;
        }

        private void TXT_ACC_TextChanged(object sender, EventArgs e)
        {
            TXT_LINE.Text = TXT_ACC.Text + TXT_MAT.Text;
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
    }
}