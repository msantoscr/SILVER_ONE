﻿using System;
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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace SILVER_E.Admininistrador
{
    public partial class frm_ptovta : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        DataSet objConsultaTV = new DataSet();
        DataTable table = new DataTable("Table");
        string nombreUser;
        string nombreSucursal="SILVER";
        string direccionSucursal="CONOCIDO";
        string rfcSucursal="XXXXXXX";
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

        public void FILL_DATA_ARTI() {
            try {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_PRODUCTS_DATA_VIEW2", mtd.conexion);
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
                DGV_ARTI.DataSource = DataT;
                GV_ARTI.BestFitColumns();
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }
        public DataSet GetTipoVenta()
        {
            mtd.ConectarBaseDatos();
            try
            {
                DataSet dtv = new DataSet();
                mtd.comando = new SqlCommand("SP_LIST_TIPO_VENTA", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_TIPO_VENTA.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_TIPO_VENTA.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_TIPO_VENTA.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_TIPO_VENTA.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador = new SqlDataAdapter(mtd.comando);
                mtd.adaptador.Fill(dtv);

                return dtv;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally {
                mtd.DesconectarBaseDatos();
            }

        }
        private void frm_ptovta_Load(object sender, EventArgs e)
        {
            
            
            table.Columns.Add("CODIGO", Type.GetType("System.Int32"));
            table.Columns.Add("LINEA", Type.GetType("System.String"));
            table.Columns.Add("DESCRIPCION", Type.GetType("System.String"));
            table.Columns.Add("PRECIO PUBLICO", Type.GetType("System.String"));
            table.Columns.Add("CANTIDAD",Type.GetType("System.Int32"));
            table.Columns.Add("DESCUENTO", Type.GetType("System.String"));
            table.Columns.Add("IMPORTE", Type.GetType("System.String"));
            table.Columns.Add("FOLIO ARTICULO", Type.GetType("System.String"));

            dgv_data.DataSource = table;
            //INICIALIZAR LA TABLA CLIENTES PARA BUSQUEDAS
            FILL_DATA();
            DATOS_COMPLEMENTA();
            GV_DATA_CLIENT.OptionsFind.AlwaysVisible = true;
            //INICIALIZAR LA TABLA ARTICULOS PARA BUSQUEDAS
            FILL_DATA_ARTI();
            GV_ARTI.OptionsFind.AlwaysVisible = true;

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            TXT_FECHA_ACTUAL.Text = fechaActual.ToString();
            objConsultaTV = GetTipoVenta();
            foreach (DataRow row in objConsultaTV.Tables[0].Rows) {
                CMB_TIPO_VENTA.Items.Add(row[0].ToString());
            }
            CMB_TIPO_VENTA.SelectedIndex = 0;
            if (CMB_TIPO_VENTA.SelectedIndex == 0) {
                this.TXT_FOLIO_DOC.Text = mtd.GeneradorVenta(usuario,Convert.ToString(CMB_TIPO_VENTA.Text.Split('*').GetValue(0).ToString().Trim()));
            }
            
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

        private void dgv_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV_ARTI_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_CODIGO_ARTI.Text = Convert.ToString(GV_ARTI.GetRowCellValue(GV_ARTI.FocusedRowHandle, "FOLIO ARTICULO"));
                TXT_CODIGO_ARTI.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void CLEAR_FIELDS() {
            TXT_CODIGO_ARTI.ResetText();
        }

        private void TXT_CODIGO_ARTI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (TXT_CODIGO_ARTI.Text == "" || TXT_CODIGO_ARTI.Text == null)
                {
                    XtraMessageBox.Show("NO PUEDES DEJAR EL CAMPO CODIGO ARTICULO VACIO", "...ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TXT_CODIGO_ARTI.Text = "";
                }
                try
                {

                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_DATOS_ARTICULOS", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;
                    mtd.comando.Parameters.Add("@CODIGO_ARTI", SqlDbType.NVarChar, 200).Value = TXT_CODIGO_ARTI.Text;
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    Message.Direction = ParameterDirection.Output;
                    mtd.comando.Parameters.Add(Message);

                    SqlDataReader reader = mtd.comando.ExecuteReader();

                    int codigo;
                    string linea;
                    string descrip;
                    string preciopub;
                    string folioArti;

                    bool existe = false;

                    if (reader.Read())
                    {
                        codigo = Convert.ToInt32(reader["ID_PRODUCTS_DATA"]);
                        linea = Convert.ToString(reader["PRD_CONCAT_MAT"]);
                        descrip = Convert.ToString(reader["PRD_NAME"]);
                        preciopub = Convert.ToString(reader["COM_PRECIO_PUB"]);
                        folioArti = Convert.ToString(reader["COM_FOLIO_ARTICULO"]);

                        if (dgv_data.RowCount > 0) {
                            for(int i=0; i < dgv_data.RowCount; i++) {
                                if (Convert.ToString(dgv_data.Rows[i].Cells["FOLIO ARTICULO"].Value) == folioArti) {
                                    XtraMessageBox.Show("EL ARTICULO YA SE ENCUENTRA INGRESADO");
                                    existe = true;
                                    break;//salir del ciclo al encontrar el registro, ya que no es necesario seguir barriendo los demas filas.
                                }
                            }
                        }
                        //fuera del ciclo, solo si no existe realizamos la insercion
                        if (existe == false) {
                            table.Rows.Add(codigo, linea, descrip, preciopub, 0, Convert.ToString(0), (Convert.ToInt32(preciopub) * 0),folioArti);
                        }

                    }
                    dgv_data.DataSource = table;
                    dgv_data.Columns[0].ReadOnly = true;
                    dgv_data.Columns[1].ReadOnly = true;
                    dgv_data.Columns[2].ReadOnly = true;
                    dgv_data.Columns[3].ReadOnly = true;
                    dgv_data.Columns[6].ReadOnly = true;
                    dgv_data.Columns[7].ReadOnly = true;

                    CLEAR_FIELDS();

                    txt_partidas.Text = this.dgv_data.RowCount.ToString();
                    TXT_CODIGO_ARTI.Focus();
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
        }

        public void fsumar()
        {
            double total = 0;
            foreach (DataGridViewRow fila in dgv_data.Rows)
            {
                if (fila.Cells["IMPORTE"].Value == null)
                {
                    return;
                }
                else
                {
                    total += Convert.ToDouble(fila.Cells["IMPORTE"].Value);
                }
            }
            txt_totales.Text = string.Format("{0:0,0}", total);
            txt_t_subtotal.Text = string.Format("{0:0,0}", total);
        }

        public void sumer_piezas()
        {
            double total = 0;
            foreach (DataGridViewRow fila in dgv_data.Rows)
            {
                if (fila.Cells["CANTIDAD"].Value == null)
                {
                    return;
                }
                else
                {
                    total += Convert.ToDouble(fila.Cells["CANTIDAD"].Value);
                }
            }

            txt_piezas.Text = Convert.ToString(total);

        }

        private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex==5) {
                Double importe;
                int descuento = Convert.ToInt32(dgv_data.Rows[e.RowIndex].Cells["DESCUENTO"].Value.ToString());

                if (Convert.ToInt32(dgv_data.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString()) != 0)
                {
                    importe = Convert.ToInt32(dgv_data.Rows[e.RowIndex].Cells["CANTIDAD"].Value.ToString()) * Convert.ToDouble(dgv_data.Rows[e.RowIndex].Cells["PRECIO PUBLICO"].Value.ToString());
                }
                else {
                     importe = Convert.ToInt32(dgv_data.Rows[e.RowIndex].Cells["PRECIO PUBLICO"].Value.ToString());
                }

                if (descuento != 0)
                {
                    dgv_data.Rows[e.RowIndex].Cells["IMPORTE"].Value = importe / descuento;
                }
                else {
                    dgv_data.Rows[e.RowIndex].Cells["IMPORTE"].Value = importe;
                }
                
            }
            fsumar();
            sumer_piezas();
            txt_partidas.Text = this.dgv_data.RowCount.ToString();
        }

        private void TXT_ID_CLIENT_TextChanged(object sender, EventArgs e)
        {
            if (TXT_ID_CLIENT.Text == "")
            {
                return;
            }
            else
            {
                search_img();
            }
        }

        public void search_img()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_OBTAIN_IMAGE_CLIENT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_OBTAIN_IMAGE_CLIENT", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //SE ENVIA COMO PARAMETRO EL ID DEL CLIENTE PARA BUSCAR EL LA IMAGEN QUE CORRESPONDE AL REGISTRO
                mtd.comando.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = TXT_ID_CLIENT.Text;

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_OBTAIN_IMAGE_CLIENT
                SqlParameter msgparam = new SqlParameter("@MENSAJE", SqlDbType.VarChar, 100);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                msgparam.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(msgparam);

                int rowsAffected = mtd.comando.ExecuteNonQuery();


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
                //DELARAMOS UNA VARIABLE TIPO LECTOR
                SqlDataReader lectores;
                //A LA VARIABLE LECTOR SE LE ASIGNA LA EJECUCION DEL COMANDO SP_OBTAIN_IMAGE_CLIENT
                lectores = mtd.comando.ExecuteReader();
                //REPETIR LA ACCION DE LEE HASTA QUE EL LECTOR LEA UN REGISTRO CON LA INFORMACION QUE SE NECESITA

                while (lectores.Read())
                {
                    byte[] result = (byte[])lectores.GetValue(0);
                    pc_img.Image = bytes_imagen(result);
                }


            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }
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

        private void BTN_DELETE_ROW_SELECT_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                dgv_data.Rows.Remove(dgv_data.CurrentRow);
                CLEAR_FIELDS();
                fsumar();
                sumer_piezas();
                txt_partidas.Text = this.dgv_data.RowCount.ToString();
                TXT_CODIGO_ARTI.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (dgv_data.DataSource is DataTable)
                {
                    ((DataTable)dgv_data.DataSource).Rows.Clear();
                    dgv_data.Refresh();
                }
                CLEAR_FIELDS();
                fsumar();
                sumer_piezas();
                txt_partidas.Text = this.dgv_data.RowCount.ToString();
                TXT_CODIGO_ARTI.Focus();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgv_data_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_data.CurrentCell.ColumnIndex == 4)

            {

                TextBox txt = e.Control as TextBox;

                if (txt != null)

                {

                    txt.KeyPress -= new KeyPressEventHandler(dgv_data_KeyPress);

                    txt.KeyPress += new KeyPressEventHandler(dgv_data_KeyPress);

                }

            }
        }

        private void dgv_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_data.CurrentCell.ColumnIndex == 4)

            {

                if (e.KeyChar == (char)Keys.Back || char.IsNumber(e.KeyChar))

                    e.Handled = false;

                else

                    e.Handled = true;

            }
        }

        private void CMB_TIPO_VENTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TXT_FOLIO_DOC.Text = mtd.GeneradorVenta(usuario, Convert.ToString(CMB_TIPO_VENTA.Text.Split('*').GetValue(0).ToString().Trim()));
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                mtd.ConectarBaseDatos();

                if (TXT_NAME_CLIENT.Text == null || TXT_NAME_CLIENT.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO EL NOMBRE DEL CLIENTE!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TXT_CURP.Text == null || TXT_CURP.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO LA CURP DEL CLIENTE!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TXT_FOLIO_DOC.Text == null || TXT_FOLIO_DOC.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO EL FOLIO DE VENTA!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TXT_ADDRESS_CLIENT.Text == null || TXT_ADDRESS_CLIENT.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO LA DIRECCION DE CLIENTE!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txt_totales.Text == "0" || txt_totales.Text == "" || txt_totales.Text == "00" || txt_totales.Text == "0.0" || txt_totales.Text == "0.00")
                {
                    XtraMessageBox.Show("¡NO SE PUEDE VENDER SI EL TOTAL DE VENTA ES CEROS!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                INSERTA_ENCABEZADO();
                INSERTAR_DETALLE_VENTA();
                IMPRIMIR_REPORTE();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public void INSERTA_ENCABEZADO() {

            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_SILV_VENTAS_INSERT", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = TXT_FOLIO_DOC.Text;
                mtd.comando.Parameters.Add("@ID_CLIENTE", SqlDbType.Int).Value = Convert.ToInt32(TXT_ID_CLIENT.Text);
                mtd.comando.Parameters.Add("@TOTAL", SqlDbType.NVarChar, 200).Value = txt_totales.Text;
                mtd.comando.Parameters.Add("@TIPO_VENTA", SqlDbType.NVarChar, 200).Value = CMB_TIPO_VENTA.Text.Split('*').GetValue(0).ToString();
                mtd.comando.Parameters.Add("@SUBTOTAL", SqlDbType.NVarChar, 200).Value = txt_t_subtotal.Text;
                mtd.comando.Parameters.Add("@PARTIDAS", SqlDbType.NVarChar, 200).Value = txt_partidas.Text;
                //FECHA SE HARA CON GETDATE();
                mtd.comando.Parameters.Add("USUARIO", SqlDbType.NVarChar, 200).Value = usuario;
                //sucursal es dentro del stored
                //ruta es dentro del stored
                mtd.comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }

        public void INSERTAR_DETALLE_VENTA() {
            try
            {
                mtd.ConectarBaseDatos();
                foreach (DataGridViewRow row in dgv_data.Rows)
                {
                    
                    string CODIGOG = Convert.ToString(row.Cells["CODIGO"].Value);
                    string LINEAG = Convert.ToString(row.Cells["LINEA"].Value);
                    string DESCRIPCIONG = Convert.ToString(row.Cells["DESCRIPCION"].Value);
                    string PRECIO_PUBLICOG = Convert.ToString(row.Cells["PRECIO PUBLICO"].Value);
                    int CANTIDADG = Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                    string DESCUENTOG = Convert.ToString(row.Cells["DESCUENTO"].Value);
                    string IMPORTEG = Convert.ToString(row.Cells["IMPORTE"].Value);
                    string FOLIOARTIG = Convert.ToString(row.Cells["FOLIO ARTICULO"].Value);

                    mtd.comando = new SqlCommand("SP_SILV_VENTAS_DETALLE_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = TXT_FOLIO_DOC.Text;
                    mtd.comando.Parameters.Add("@ID_ARTICULO", SqlDbType.NVarChar, 200).Value = CODIGOG;
                    mtd.comando.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = CANTIDADG;
                    mtd.comando.Parameters.Add("@LINEA", SqlDbType.NVarChar, 200).Value = LINEAG;
                    mtd.comando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar, 200).Value = DESCRIPCIONG;
                    mtd.comando.Parameters.Add("@PRECIO_PUBLICO", SqlDbType.NVarChar, 200).Value = PRECIO_PUBLICOG;
                    mtd.comando.Parameters.Add("@DESCUENTO", SqlDbType.NVarChar, 200).Value = DESCUENTOG;
                    mtd.comando.Parameters.Add("@IMPORTE", SqlDbType.NVarChar, 200).Value = IMPORTEG;
                    mtd.comando.Parameters.Add("@FOLIO_ARTICULO", SqlDbType.NVarChar, 200).Value = FOLIOARTIG;

                    mtd.comando.ExecuteNonQuery();
                }



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }

        public void IMPRIMIR_REPORTE() {
            try
            {

                DataSet ds_venta = new DataSet();
                //PrintDialog printDialog = new PrintDialog();

                //if (printDialog.ShowDialog() == DialogResult.OK)
                //{


                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_OBTENER_NOTA_VENTA", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;
                    mtd.comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = TXT_FOLIO_DOC.Text;
                    mtd.comando.Parameters.Add("@ID_CLIENTE", SqlDbType.NVarChar, 200).Value = TXT_ID_CLIENT.Text;
                    mtd.comando.ExecuteNonQuery();

                   

                SqlDataAdapter adt = new SqlDataAdapter(mtd.comando);
                    adt.Fill(ds_venta, "DsNotaVenta");

                     
                    ReportDocument reportDocument = new ReportDocument();
                    PrinterSettings ps = new PrinterSettings();
                    ps.Copies = 1;
                    PageSettings pg = new PageSettings();
                    pg.PrinterSettings = ps;
                    reportDocument.Load(Application.StartupPath + "\\Admininistrador\\ReporteVenta.rpt");
                    
                    reportDocument.SetDataSource(ds_venta);

                    reportDocument.SetParameterValue("NOMBRE_USER", nombreUser);
                    reportDocument.SetParameterValue("NOMBRE_EMP", nombreSucursal);
                    reportDocument.SetParameterValue("DIRECCION_SUCURSAL", direccionSucursal);
                    reportDocument.SetParameterValue("RFC_SUCURSAL", rfcSucursal);
                    reportDocument.SetParameterValue("textFecha",TXT_FECHA_ACTUAL.Text);
                    reportDocument.SetParameterValue("FOLIO_VENTA", TXT_FOLIO_DOC.Text);
                    reportDocument.SetParameterValue("Nombre",TXT_NAME_CLIENT.Text);
                    reportDocument.SetParameterValue("direccion", TXT_ADDRESS_CLIENT.Text);
                    reportDocument.SetParameterValue("Curp", TXT_CURP.Text);
                    reportDocument.SetParameterValue("TipoVta", CMB_TIPO_VENTA.Text.Split('*').GetValue(1).ToString().Trim());
                    reportDocument.SetParameterValue("PIEZAS", txt_piezas.Text);
                    reportDocument.SetParameterValue("SUBTOTAL","$ "+txt_t_subtotal.Text);
                    reportDocument.SetParameterValue("total", "$ " + txt_totales.Text);
                    reportDocument.PrintToPrinter(ps,pg,false);

                //}               

                XtraMessageBox.Show("SE GUARDO CORRECTAMENTE LA VENTA!!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                mtd.DesconectarBaseDatos();
                this.TXT_FOLIO_DOC.Text = mtd.GeneradorVenta(usuario, Convert.ToString(CMB_TIPO_VENTA.Text.Split('*').GetValue(0).ToString().Trim()));
                BTN_DELETE_ItemClick(null, null);
            }
        }

        public void DATOS_COMPLEMENTA() {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SILV_VENTA_DATOS_COMPLEMENTARIOS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.Parameters.Add("@USUARIO", SqlDbType.NVarChar, 200).Value = usuario;
                mtd.lector = mtd.comando.ExecuteReader();
                if (mtd.lector.Read())
                {
                    nombreUser = Convert.ToString(mtd.lector["AG_NAME_AGENT"]);
                    nombreSucursal = Convert.ToString(mtd.lector["COM_NAME_COMPANY"]);
                    direccionSucursal = Convert.ToString(mtd.lector["COM_ADDRESS"]);
                    rfcSucursal = Convert.ToString(mtd.lector["COM_RFC"]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }
    }
}