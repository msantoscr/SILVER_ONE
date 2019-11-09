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
    public partial class frm_clients : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string[] array_nombres;
        Metodos mtd = new Metodos();
        frn_main_form frn_menu;
        public frm_clients()
        {
            InitializeComponent();
        }
        public void LIST_FOLIO()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_LIST_CODE_CLIENT", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //SE ENVIA COMO PARAMETRO EL NOMBRE DEL USUARIO ACTUAL PARA PODER OBTENER EL FOLIO CORRESPONDIENTE
                mtd.comando.Parameters.Add("@US_USERNAME", SqlDbType.NVarChar, 100).Value = frn_menu.LBL_USERNAME.Caption;
                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_CODE_CLIENT
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_CODE_CLIENT", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_CODE_CLIENT SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_CODE_CLIENT
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_FOLIO LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_FOLIO.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_FOLIO.ValueMember = "ID_FOLIOS"; //EL VALOR QUE TENDRA
                CB_FOLIO.DisplayMember = "FO_CONCAT"; //EL VALOR QUE SE MOSTRARA

            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_CITY() {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_CITY E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_CITY", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_CITY
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_CITY", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_CITY SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_CODE_CITY
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_FOLIO LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_CITY.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_CITY.ValueMember = "ID_CITY"; //EL VALOR QUE TENDRA
                CB_CITY.DisplayMember = "CI_NAME"; //EL VALOR QUE SE MOSTRARA
            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_ESTATUS() {
            try
            {
                //ESTABLECE LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_ESTATUS_CLIENT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_ESTATUS_CLIENT", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_ESTATUS_CLIENT
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_ESTATUS_CLIENT", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_ESTATUS_CLIENT SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)

                if (mtd.Rows > 0)
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_ESTATUS_CLIENT
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_STATUS LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_STATUS.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_STATUS.ValueMember = "ID_STATUS_CLIENT"; //EL VALOR QUE TENDRA
                CB_STATUS.DisplayMember = "ST_NAME"; //EL VALOR QUE SE MOSTRARA

            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_VALUE_ESTATUS() {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_VALUE_STATUS_CLIENTS_CLIENTS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_VALUE_STATUS_CLIENTS_CLIENTS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                mtd.comando.Parameters.Add("@ID_STATUS_CLIENT", SqlDbType.NVarChar, 100).Value = TXT_ID.Text; //SE ENVIA COMO PARAMETRO EL ID_STATUS_CLIENT UNA VEZ PRESIONADO DOS VECES CLIC EN LA TABLA DE REGISTROS

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_ESTATUS_CLIENT
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_VALUE_STATUS_CLIENTS_CLIENTS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_VALUE_STATUS_CLIENTS_CLIENTS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_FOLIO.Visibility = BarItemVisibility.Always;
                    LB_FOLIO.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_VALUE_STATUS_CLIENTS_CLIENTS
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_STATUS LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_STATUS.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_STATUS.ValueMember = "ID_STATUS_CLIENT"; //EL VALOR QUE TENDRA
                CB_STATUS.DisplayMember = "ST_NAME"; //EL VALOR QUE SE MOSTRARA
            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void FILL_DATA() {
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
                    LB_RESULT.Visibility = BarItemVisibility.Always;
                    LB_RESULT.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_RESULT.Visibility = BarItemVisibility.Always;
                    LB_RESULT.Caption = Convert.ToString(Message.Value);
                }

                //CREAMOS UN ADAPTADOR PARA EL COMANDO
                mtd.adaptador = new SqlDataAdapter(mtd.comando);
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //NDICAMOS QUE LA FUENTE DE DATOS DEL CONTROL GRIDCONTROL SERA UN DATATABLE
                DGV_DATA.DataSource = DataT;
                //AL GRIDVIEW QUE SE CONTIENE DESDE EL GRIDCONTROL SE AJUSTARAN SUS COLUMNAS AL CONTENIDO DEL TEXTO 
                G_DATA.BestFitColumns();
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
        byte img;
        #region "METODOS IMAGEN"
        //metodo que convierte de imagen a binario
        public static byte[] imagen_bytes(Image img)
        {
            if (img != null)
            {
                MemoryStream bin = new MemoryStream();
                img.Save(bin, System.Drawing.Imaging.ImageFormat.Jpeg);
                return bin.GetBuffer();
            }
            else {
                return null;
            }
        }

        //metdo queconvierte de binario a imagen
        public static Image bytes_imagen(byte[] Imagen)
        {
            if (Imagen == null) return null;

            try
            {
                MemoryStream bin = new MemoryStream(Imagen);
                Image resultado = Image.FromStream(bin);
                return resultado;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public void search_img() {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_OBTAIN_IMAGE_CLIENT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_OBTAIN_IMAGE_CLIENT", mtd.conexion);
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //SE ENVIA COMO PARAMETRO EL ID DEL CLIENTE PARA BUSCAR EL LA IMAGEN QUE CORRESPONDE AL REGISTRO
                mtd.comando.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = TXT_ID.Text;

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
                do
                {
                    byte[] b = null;
                    b = (byte[])lectores.GetValue(0);
                    pc_img.EditValue = bytes_imagen(b);
                } while (lectores.Read());

            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }

        public void clean_fields() {
            TXT_ID.ResetText();
            TX_CALLE.ResetText();
            TX_COLONIA.ResetText();
            TX_CRUZ.ResetText();
            TX_CURP.ResetText();
            TX_EXTERIOR.ResetText();
            TX_INTERIOR.ResetText();
            //TX_LOCAL.ResetText()
            TX_MAT.ResetText();
            TX_NAME.ResetText();
            TX_OBS.ResetText();
            TX_PAT.ResetText();

            TX_TELEFONO.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
            this.pc_img.Image = null;
        }
        #endregion

        private void frm_clients_Load(object sender, EventArgs e)
        {

            //llena en automatico las listas cada que el formulario es mostrado por primera vez
            LIST_FOLIO(); //LISTAR LOS FOLIOS
        LIST_CITY(); //LISTAR LAS CIUDADES
        LIST_ESTATUS(); //LISTAR LOS ESTATUS

            //SE UTILIZA EL ARREGLO BIDIMENSIONAL Y SE LE ASIGNAN LOS VALORES DE LOS ESTADOS
            


            }
        }
    }
}