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
    public partial class frm_cobranza : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        public frm_cobranza(string usu)
        {
            usuario = usu;
            InitializeComponent();
        }

        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_OBTENER_PEDIDOS_COBRANZA", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 200).Value = usuario;
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);

                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_PEDIDO.Visibility = BarItemVisibility.Always;
                    LBL_PEDIDO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_PEDIDO.Visibility = BarItemVisibility.Always;
                    LBL_PEDIDO.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador = new SqlDataAdapter(mtd.comando);
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);
                DGV_PEDIDO.DataSource = DataT;
                G_PEDIDO.BestFitColumns();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }

        private void frm_cobranza_Load(object sender, EventArgs e)
        {
            FILL_DATA();
            G_PEDIDO.OptionsFind.AlwaysVisible = true;
        }

        private void DGV_PEDIDO_DoubleClick(object sender, EventArgs e)
        {
            try {
                TXT_PEDIDO.Text = Convert.ToString(G_PEDIDO.GetRowCellValue(G_PEDIDO.FocusedRowHandle,"FOLIO_VENTA"));
                TXT_NAME_CLIENT.Text = Convert.ToString(G_PEDIDO.GetRowCellValue(G_PEDIDO.FocusedRowHandle, "CL_COMPLETE_NAME"));
                TXT_ADDRESS_CLIENT.Text = Convert.ToString(G_PEDIDO.GetRowCellValue(G_PEDIDO.FocusedRowHandle, "DIRECCION"));
                TXT_ID_CLIENT.Text = Convert.ToString(G_PEDIDO.GetRowCellValue(G_PEDIDO.FocusedRowHandle, "ID_CLIENTE"));
                TXT_CURP.Text = Convert.ToString(G_PEDIDO.GetRowCellValue(G_PEDIDO.FocusedRowHandle, "CL_CURP"));

            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}