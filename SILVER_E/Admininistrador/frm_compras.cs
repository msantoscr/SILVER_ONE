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
    public partial class frm_compras : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        DataTable table = new DataTable("Table");
        
        public frm_compras(string usu)
        {
            usuario = usu;
            InitializeComponent();
            TXT_COSTO_UNIT.Text = "0";
            TXT_CANTIDAD.Text = "0";
        }

        public void LIST_PROVIDERS()
        {
            try
            {
                //SE ESTABLECE LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_PROVIDERS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_PROVIDERS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_PROVIDER.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_PROVIDER.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_PROVIDER.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_PROVIDER.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                //mtd.adaptador.SelectCommand = mtd.comando;

                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                da.Fill(DataT);
                //AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_PROVIDER.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_PROVIDER.ValueMember = "ID_PROVIDERS"; //EL VALOR QUE TENDRA
                CB_PROVIDER.DisplayMember = "PROVEEDOR"; //EL VALOR QUE SE MOSTRARA
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

        public void LIST_WAREHOUSE()
        {
            try
            {

                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_WAREHOUSE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_WAREHOUSE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;


                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_WAREHOUSE
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_WAREHOUSE", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_WAREH.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_WAREH.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_WAREH.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_WAREH.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_WAREHOUSE
                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                //mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                da.Fill(DataT);
                //AL CONTROL CB_ALMACEN LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_ALMACEN.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_ALMACEN.ValueMember = "ID_WAREHOUSE"; //EL VALOR QUE TENDRA
                CB_ALMACEN.DisplayMember = "ALM_NUMBER_WAREHOUSE"; //EL VALOR QUE SE MOSTRARA

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

        public void LIST_ACCESSORIES()
        {

            try
            {
                //SE ESTABLECE LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_PROVIDERS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_ACCESSORIES", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    lbl_result_acc.Visibility = BarItemVisibility.Always;
                    lbl_result_acc.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    lbl_result_acc.Visibility = BarItemVisibility.Always;
                    lbl_result_acc.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                da.Fill(DataT);
                //AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_ACCESORIO.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_ACCESORIO.ValueMember = "ID_ACCESSORIES"; //EL VALOR QUE TENDRA
                CB_ACCESORIO.DisplayMember = "AC_NAME_ACCESORIES"; //EL VALOR QUE SE MOSTRARA

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR LIST_ACCESSORIES", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }

        }

        public void LIST_MATERIAL()
        {
            try
            {
                //SE ESTABLECE LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_MATERIAL E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_MATERIAL", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    lbl_result_mat.Visibility = BarItemVisibility.Always;
                    lbl_result_mat.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    lbl_result_mat.Visibility = BarItemVisibility.Always;
                    lbl_result_mat.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                da.Fill(DataT);
                //AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_MATERIAL.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_MATERIAL.ValueMember = "ID_MATERIAL"; //EL VALOR QUE TENDRA
                CB_MATERIAL.DisplayMember = "MA_NAME_MATERIAL"; //EL VALOR QUE SE MOSTRARA

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR LIST_MATERIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mtd.DesconectarBaseDatos();

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

        public void LIST_DESCRIPTION()
        {
            try
            {
                //SE ESTABLECE LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_DESCRIPTION_ARTICLE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_DESCRIPTION_ARTICLE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                mtd.comando.Parameters.Add("@PRD_CONCAT_MAT", SqlDbType.NVarChar, 100).Value = TXT_LINEA.Text;
                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_PROVIDERS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    lbl_result_desc.Visibility = BarItemVisibility.Always;
                    lbl_result_desc.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    lbl_result_desc.Visibility = BarItemVisibility.Always;
                    lbl_result_desc.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_PROVIDERS
                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                da.Fill(DataT);
                //AL CONTROL CB_PROVIDER LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_DESCRIPCION.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_DESCRIPCION.ValueMember = "PRD_NAME"; //EL VALOR QUE TENDRA
                CB_DESCRIPCION.DisplayMember = "PRD_NAME"; //EL VALOR QUE SE MOSTRARA

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR LIST_DESCRIPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }
        public void CLEAR_FIELDS()
        {
            TXT_CANTIDAD.Text="0";
            TXT_COSTO_UNIT.Text="0";
            TXT_ID.ResetText();
            TXT_IMPORTE.Text="0";
            //TXT_LINEA.ResetText();
            TXT_PRECION_PUB.Text="0";
            //TXT_T_COMPRA.ResetText();
            TXT_CANTIDAD.Focus();
        }

        public void UPDATE_GENERATOR()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_UPDATE_GENERATOR", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.ExecuteNonQuery();
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

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                mtd.ConectarBaseDatos();
                foreach (DataGridViewRow row in dgv_data.Rows)
                {
                    string Cantidad = Convert.ToString(row.Cells["CANTIDAD"].Value);
                    string Accesorio = Convert.ToString(row.Cells["ACCESORIO"].Value);
                    string Material = Convert.ToString(row.Cells["MATERIAL"].Value);
                    string Linea = Convert.ToString(row.Cells["LINEA"].Value);
                    string Descripcion = Convert.ToString(row.Cells["DESCRIPCION"].Value);
                    string Costo_Unit = Convert.ToString(row.Cells["COSTO UNITARIO"].Value);
                    string Precio_Pub = Convert.ToString(row.Cells["PRECIO PUBLICO"].Value);
                    string Importe = Convert.ToString(row.Cells["IMPORTE"].Value);

                    mtd.comando = new SqlCommand("SP_SILV_COMPRAS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@COM_PROVEEDOR", SqlDbType.NVarChar, 100).Value = CB_PROVIDER.Text;
                    mtd.comando.Parameters.Add("@COM_WAREHOUSE", SqlDbType.NVarChar, 100).Value = CB_ALMACEN.Text;
                    mtd.comando.Parameters.Add("@COM_FOLIO_DOCUMENT", SqlDbType.NVarChar, 50).Value = TXT_FOLIO_DOC.EditValue;
                    mtd.comando.Parameters.Add("@COM_FECHA_CMP", SqlDbType.Date).Value = DT_FECHA.EditValue;
                    mtd.comando.Parameters.Add("@COM_CANTIDAD", SqlDbType.Int).Value = Cantidad;
                    mtd.comando.Parameters.Add("@COM_ACCESORIO", SqlDbType.NVarChar, 10).Value = Accesorio;

                    mtd.comando.Parameters.Add("@COM_MATERIAL", SqlDbType.NVarChar, 10).Value = Material;
                    mtd.comando.Parameters.Add("@COM_LINEA", SqlDbType.NVarChar, 50).Value = Linea;
                    mtd.comando.Parameters.Add("@COM_DESCRIPCION", SqlDbType.NVarChar, 200).Value = Descripcion;
                    mtd.comando.Parameters.Add("@COM_PIEZAS", SqlDbType.Int).Value = txt_piezas.Text;
                    mtd.comando.Parameters.Add("@COM_PARTIDAS", SqlDbType.Int).Value = txt_partidas.Text;
                    mtd.comando.Parameters.Add("@COM_COSTO_UNIT", SqlDbType.Float).Value = Costo_Unit;
                    mtd.comando.Parameters.Add("@COM_PRECIO_PUB", SqlDbType.Float).Value = Precio_Pub;
                    mtd.comando.Parameters.Add("@COM_IMPORTE", SqlDbType.Float).Value = Importe;
                    mtd.comando.Parameters.Add("@COM_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_COUNTRIES_INSERT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_COUNTRIES_INSERT", connection)
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_COUNTRIES_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                    if (mtd.Rows > 0)
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }
                    else
                    {
                        XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                mtd.DesconectarBaseDatos();
                //LIMPIAMOS LOS CAMPOS
                CLEAR_FIELDS();
                //  dgv_data.DataSource = Nothing
                UPDATE_GENERATOR();
                this.TXT_FOLIO_DOC.Text = mtd.Generadores("COM_PARAMETRO");
            }
        }

        private void frm_compras_Load(object sender, EventArgs e)
        {
            this.TXT_FOLIO_DOC.Text = mtd.Generadores("COM_PARAMETRO");
            TXT_CANTIDAD.Focus();
            table.Columns.Add("CANTIDAD", Type.GetType("System.Int32"));
            table.Columns.Add("ACCESORIO", Type.GetType("System.String"));
            table.Columns.Add("MATERIAL", Type.GetType("System.String"));
            table.Columns.Add("LINEA", Type.GetType("System.String"));
            table.Columns.Add("DESCRIPCION", Type.GetType("System.String"));
            table.Columns.Add("COSTO UNITARIO", Type.GetType("System.String"));
            table.Columns.Add("PRECIO PUBLICO", Type.GetType("System.String"));
            table.Columns.Add("IMPORTE", Type.GetType("System.String"));

            dgv_data.DataSource = table;

            DT_FECHA.EditValue = DateTime.Now;
            //Realizamos el listado del PROVEEDOR
            LIST_PROVIDERS();
            //Realizamos el listado de los almacenes disponibles
            LIST_WAREHOUSE();


            //listados adicionales
            LIST_ACCESSORIES();
            LIST_MATERIAL();
            TXT_LINEA.Text = CB_ACCESORIO.Text + CB_MATERIAL.Text;
            LIST_DESCRIPTION();
        }

        private void CB_MATERIAL_TextChanged(object sender, EventArgs e)
        {
            TXT_LINEA.Text = CB_ACCESORIO.Text + CB_MATERIAL.Text;
        }

        private void TXT_COSTO_UNIT_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXT_CANTIDAD_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void CB_DESCRIPCION_Enter(object sender, EventArgs e)
        {
            LIST_DESCRIPTION();

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            bool valida = false;
            if (TXT_CANTIDAD.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA CANTIDAD DE LAS PIEZAS", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //ACCESORIO
            if (CB_ACCESORIO.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL ACCESORIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //MATERIAL
            if (CB_MATERIAL.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL ACCESORIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //LINEA
            if (TXT_LINEA.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA LINEA DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //DESCRIPCION
            if (CB_DESCRIPCION.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA DESCRIPCION DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //COSTO UNITARIO
            if (TXT_COSTO_UNIT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL COSTO UNITARIO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //PRECIO PUBLICO
            if (TXT_PRECION_PUB.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL PRECIO PUBLICO DE LA PIEZA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            //IMPORTE
            if (TXT_IMPORTE.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IMPORTE DE LAS PIEZAS", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            table.Rows.Add(TXT_CANTIDAD.Text, CB_ACCESORIO.Text, CB_MATERIAL.Text, TXT_LINEA.Text, CB_DESCRIPCION.Text, TXT_COSTO_UNIT.Text, TXT_PRECION_PUB.Text, TXT_IMPORTE.Text);
            dgv_data.DataSource = table;
            CLEAR_FIELDS();
            fsumar();
            sumer_piezas();
            txt_partidas.Text = this.dgv_data.RowCount.ToString();
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                foreach (DataGridViewRow row in dgv_data.Rows)
                {
                    dgv_data.Rows.Remove(row);
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BTN_DELETE_ROW_SELEC_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                dgv_data.Rows.Remove(dgv_data.CurrentRow);
                CLEAR_FIELDS();
                fsumar();
                sumer_piezas();
                txt_partidas.Text = this.dgv_data.RowCount.ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            fsumar();
            sumer_piezas();
            txt_partidas.Text = this.dgv_data.RowCount.ToString();
        }

        private void CB_MATERIAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //e.KeyChar =e.KeyChar.ToString().ToUpper().ToCharArray(0,1)[0];
        }

        private void CB_ACCESORIO_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);

        }

        private void TXT_CANTIDAD_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if ((int)e.KeyChar == (int)Keys.Enter) {
                if (TXT_CANTIDAD.Text=="" || TXT_CANTIDAD.Text == null) {
                    XtraMessageBox.Show("NO PUEDES DEJAR EL CAMPO CANTIDAD VACIO", "...ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TXT_CANTIDAD.Text = "0";
                }
                TXT_IMPORTE.Text = Convert.ToString(Convert.ToInt32(TXT_CANTIDAD.Text) * Convert.ToInt32(TXT_COSTO_UNIT.Text));
                TXT_COSTO_UNIT.Focus();
            }
        }

        private void TXT_COSTO_UNIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) {

                if (TXT_COSTO_UNIT.Text == "" || TXT_COSTO_UNIT.Text == null)
                {
                    XtraMessageBox.Show("NO PUEDES DEJAR EL CAMPO COSTO UNITARIO VACIO", "...ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TXT_COSTO_UNIT.Text = "0";
                }
                    TXT_PRECION_PUB.Text = Convert.ToString(Convert.ToInt32(TXT_COSTO_UNIT.Text) * 3);
                    TXT_IMPORTE.Text = Convert.ToString(Convert.ToInt32(TXT_CANTIDAD.Text) * Convert.ToInt32(TXT_COSTO_UNIT.Text));
                
            }
        }
    }
}