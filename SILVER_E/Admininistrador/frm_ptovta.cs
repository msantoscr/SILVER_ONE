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
using DevExpress.XtraScheduler.Native;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace SILVER_E.Admininistrador
{
    public partial class frm_ptovta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        DataSet objConsultaClientes = new DataSet();
        
        public frm_ptovta(string usu)
        {
            usuario = usu;
            InitializeComponent();
            
        }
        public void FILL_DATA()
        {
            try
            {

                mtd.ConectarBaseDatos();

                mtd.comando = new SqlCommand("SP_SILV_CLIENTS_VIEW", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_VIEW
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_USERS_VIEW", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
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

                //CREAMOS UN ADAPTADOR PARA EL COMANDO
                mtd.adaptador = new SqlDataAdapter(mtd.comando);
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //NDICAMOS QUE LA FUENTE DE DATOS DEL CONTROL GRIDCONTROL SERA UN DATATABLE
                DGV_DATA_CLIENT.DataSource = DataT;
                //AL GRIDVIEW QUE SE CONTIENE DESDE EL GRIDCONTROL SE AJUSTARAN SUS COLUMNAS AL CONTENIDO DEL TEXTO 
                GV_DATA_CLIENT.BestFitColumns();
            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }
        private void frm_ptovta_Load(object sender, EventArgs e)
        {
            FILL_DATA();
            GV_DATA_CLIENT.OptionsFind.AlwaysVisible = true;
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            TXT_FECHA_ACTUAL.Text = fechaActual.ToString();
            
        }

        private void BTN_FIND_Click(object sender, EventArgs e)
        {

        }

        private void DGV_DATA_CLIENT_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID_CLIENT.Text = Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "ID"));
                TXT_NAME_CLIENT.Text = Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "NOMBRE(s)") +" "+ GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "APELLIDO PATERNO") +" "+ GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "APELLIDO MATERNO"));
                TXT_ADDRESS_CLIENT.Text = Convert.ToString(
                    Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "CALLE")) + " "+
                    Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "Nº EXTERIOR"))+ " "+
                    Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "COLONIA"))
                    );
                if (GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "CURP") == DBNull.Value)
                {
                    TXT_CURP.Text = "";
                }
                else
                {
                    TXT_CURP.Text = Convert.ToString(GV_DATA_CLIENT.GetRowCellValue(GV_DATA_CLIENT.FocusedRowHandle, "CURP"));
                }
               

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frm_ptovta_Shown(object sender, EventArgs e)
        {
            TXT_CODIGO_ARTI.Focus();
        }
    }
}