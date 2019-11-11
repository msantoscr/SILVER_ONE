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
        string[,] array_nombres;
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
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_CITY()
        {
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
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_ESTATUS()
        {
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
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_VALUE_ESTATUS()
        {
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
            finally
            {
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
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
            else
            {
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
            catch (Exception ex)
            {
                return null;
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
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }

        public void clean_fields()
        {
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

            string[,] array_nombres = {{"", ""},
           {"AGUASCALIENTES", "AS"},
           {"BAJA CALIFORNIA", "BC"},
           {"BAJA CALIFORNIA SUR", "BS"},
            {"CAMPECHE", "CC"},
               {"CHIAPAS", "CS"},
               {"CHIHUAHUA", "CH"},
               {"COAHUILA", "CL"},
               {"COLIMA", "CM"},
               {"DISTRITO FEDERAL", "DF"},
               {"DURANGO", "DG"},
               {"GUANAJUATO", "GT"},
               {"GUERRERO", "GR"},
               {"HIDALGO", "HG"},
               {"JALISCO", "JC"},
               {"MEXICO", "MC"},
               {"MICHOACAN", "MN"},
               {"MORELOS", "MS"},
               {"NAYARIT", "NT"},
               {"NUEVO LEON", "NL"},
               {"OAXACA", "OC"},
               {"PUEBLA", "PL"},
               {"QUERETARO", "QT"},
               {"QUINTANA ROO", "QR"},
               {"SAN LUIS POTOSI", "SP"},
               {"SINALOA", "SL"},
               {"SONORA", "SR"},
               {"TABASCO", "TC"},
               {"TAMAULIPAS", "TS"},
               {"TLAXCALA", "TL"},
               {"VERACRUZ", "VZ"},
               {"YUCATÁN", "YN"},
               {"ZACATECAS", "ZS"},
               {"NACIDO EXTRANJERO", "NE"}};

            int contador = 0;
            CB_ESTADO.Items.Add("Selecciona");
            CB_ESTADO.SelectedIndex = 0;
            CB_ESTADO.DropDownStyle = ComboBoxStyle.DropDownList;
            while (contador <= array_nombres.Length - 2)
            {
                CB_ESTADO.Items.Add(array_nombres[contador, 0]);
                contador++;
            }
            CB_ESTADO.Items.Remove("");
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;
            if (TX_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TX_PAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO PATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TX_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO MATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TX_CALLE.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR CALLE/DIRECCION PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }

            if (VALIDA == true)
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_CLIENTS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    // .Parameters.Add("@ID_USER", SqlDbType.Int).Value = TXT_ID.Text
                    mtd.comando.Parameters.Add("@CL_CITY", SqlDbType.NVarChar, 50).Value = CB_CITY.Text;
                    mtd.comando.Parameters.Add("@CL_STATE", SqlDbType.NVarChar, 50).Value = CB_ESTADO.Text;
                    mtd.comando.Parameters.Add("@ID_STATUS_CLIENT", SqlDbType.Int).Value = CB_STATUS.SelectedValue;

                    mtd.comando.Parameters.Add("@CL_NAME", SqlDbType.NVarChar, 200).Value = TX_NAME.Text;
                    mtd.comando.Parameters.Add("@CL_PATERN_SURNAME", SqlDbType.NVarChar, 50).Value = TX_PAT.Text;
                    mtd.comando.Parameters.Add("@CL_MATERNAL_SURNAME", SqlDbType.NVarChar, 100).Value = TX_MAT.Text;
                    //sexo
                    mtd.comando.Parameters.Add("@CL_SEX", SqlDbType.NVarChar, 50).Value = R_SEX.EditValue;
                    mtd.comando.Parameters.Add("@CL_DATE_BORN", SqlDbType.Date).Value = DT_FECHA_NAC.EditValue;

                    if (TX_CURP.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_CURP", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_CURP", SqlDbType.NVarChar, 200).Value = TX_CURP.Text;
                    }

                    if (TX_CALLE.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_STREET", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_STREET", SqlDbType.NVarChar, 200).Value = TX_CALLE.Text;
                    }


                    if (TX_EXTERIOR.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_NO_EXT", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_NO_EXT", SqlDbType.NVarChar, 200).Value = TX_EXTERIOR.Text;
                    }

                    if (TX_INTERIOR.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_NO_INT", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_NO_INT", SqlDbType.NVarChar, 200).Value = TX_INTERIOR.Text;
                    }

                    if (TX_CRUZ.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_CRZMNT", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_CRZMNT", SqlDbType.NVarChar, 200).Value = TX_CRUZ.Text;
                    }

                    if (TX_COLONIA.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_COLOGNE", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_COLOGNE", SqlDbType.NVarChar, 200).Value = TX_COLONIA.Text;
                    }

                    if (TX_TELEFONO.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_PHONE", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_PHONE", SqlDbType.NVarChar, 200).Value = TX_TELEFONO.Text;
                    }

                    if (CB_PREF.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_CLASIF", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_CLASIF", SqlDbType.NVarChar, 200).Value = CB_PREF.Text;
                    }

                    mtd.comando.Parameters.Add("@CL_TYPE", SqlDbType.NVarChar, 100).Value = R_TIPO.EditValue;

                    if (TX_OBS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@CL_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CL_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TX_OBS.Text;
                    }

                    mtd.comando.Parameters.Add("@CL_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    mtd.comando.Parameters.Add("@CL_USER_CREATOR", SqlDbType.NVarChar, 100).Value = frn_menu.LBL_USERNAME.Caption;
                    mtd.comando.Parameters.Add("@CL_KEY", SqlDbType.NVarChar, 50).Value = CB_FOLIO.Text;

                    img = Convert.ToByte(imagen_bytes(pc_img.Image));

                    mtd.comando.Parameters.AddWithValue("@CL_FOTO", img);

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
                    clean_fields();
                    FILL_DATA();
                }
            }

        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool VALIDA = false;
            if (TX_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TX_PAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO PATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TX_MAT.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR SU APELLIDO MATERNO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (VALIDA == true)
            {
                XtraMessageBox.Show("FALTA INFORMACION POR ESPECIFICAR EN EL SISTEMA", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA MODIFICAR LA INFORMACION DEL CLIENTE?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_CLIENTS_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;

                        mtd.comando.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = TXT_ID.Text;
                        mtd.comando.Parameters.Add("@CL_CITY", SqlDbType.NVarChar, 50).Value = CB_CITY.Text;
                        mtd.comando.Parameters.Add("@CL_STATE", SqlDbType.NVarChar, 50).Value = CB_ESTADO.Text;
                        mtd.comando.Parameters.Add("@ID_STATUS_CLIENT", SqlDbType.Int).Value = CB_STATUS.SelectedValue;

                        mtd.comando.Parameters.Add("@CL_NAME", SqlDbType.NVarChar, 200).Value = TX_NAME.Text;
                        mtd.comando.Parameters.Add("@CL_PATERN_SURNAME", SqlDbType.NVarChar, 50).Value = TX_PAT.Text;
                        mtd.comando.Parameters.Add("@CL_MATERNAL_SURNAME", SqlDbType.NVarChar, 100).Value = TX_MAT.Text;


                        mtd.comando.Parameters.Add("@CL_SEX", SqlDbType.NVarChar, 50).Value = R_SEX.EditValue;
                        mtd.comando.Parameters.Add("@CL_DATE_BORN", SqlDbType.Date).Value = DT_FECHA_NAC.EditValue;

                        if (TX_CURP.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_CURP", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_CURP", SqlDbType.NVarChar, 200).Value = TX_CURP.Text;
                        }


                        //  .Parameters.Add("@CL_STREET", SqlDbType.NVarChar, 100).Value = TX_CALLE.Text
                        if (TX_CALLE.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_STREET", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_STREET", SqlDbType.NVarChar, 200).Value = TX_CALLE.Text;
                        }


                        if (TX_EXTERIOR.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_NO_EXT", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_NO_EXT", SqlDbType.NVarChar, 200).Value = TX_EXTERIOR.Text;
                        }

                        if (TX_INTERIOR.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_NO_INT", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_NO_INT", SqlDbType.NVarChar, 200).Value = TX_INTERIOR.Text;
                        }

                        if (TX_CRUZ.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_CRZMNT", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_CRZMNT", SqlDbType.NVarChar, 200).Value = TX_CRUZ.Text;
                        }

                        if (TX_COLONIA.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_COLOGNE", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_COLOGNE", SqlDbType.NVarChar, 200).Value = TX_COLONIA.Text;
                        }


                        if (TX_TELEFONO.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_PHONE", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_PHONE", SqlDbType.NVarChar, 200).Value = TX_TELEFONO.Text;
                        }

                        if (CB_PREF.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_CLASIF", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_CLASIF", SqlDbType.NVarChar, 200).Value = CB_PREF.Text;
                        }

                        mtd.comando.Parameters.Add("@CL_TYPE", SqlDbType.NVarChar, 100).Value = R_TIPO.EditValue;

                        if (TX_OBS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CL_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CL_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TX_OBS.Text;
                        }

                        mtd.comando.Parameters.Add("@CL_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        mtd.comando.Parameters.Add("@CL_USER_UPDATE", SqlDbType.NVarChar, 100).Value = frn_menu.LBL_USERNAME.Caption;
                        mtd.comando.Parameters.Add("@CL_KEY", SqlDbType.NVarChar, 50).Value = CB_FOLIO.Text;


                        img = Convert.ToByte(imagen_bytes(this.pc_img.Image));
                        mtd.comando.Parameters.AddWithValue("@CL_FOTO", img);


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
                        clean_fields();
                        FILL_DATA();
                    }
                }
            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("NO DISPONIBLE", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void SHOW_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = true;
            SHOW_PANEL.Enabled = false;
            HIDE_PANEL.Enabled = true;
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
                LIST_VALUE_ESTATUS();
            }
        }

        private void BTN_CLEAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            clean_fields();
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //declaramos un cuadro de dialogo referenciado por openfilediaog1
            DialogResult result = new DialogResult(); //el resultado del cuadro que declaramos


            openFileDialog1.InitialDirectory = "Bibliotecas\\Imágenes\\Imagenes públicas\\Imagenes de muestra"; //damos el directorio inicial es donde buscara primero
            openFileDialog1.Filter = "archivos de imagen (*.jpg)|*.png|All files (*.*)|*.*"; //'le damos 
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.RestoreDirectory = true;
            result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {

                pc_img.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void BTN_REFRESH_CITY_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_CITY();
        }

        private void BTN_REFRESH_STATUS_C_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_ESTATUS();
        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TX_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE(s)"));
                TX_PAT.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO PATERNO"));
                TX_MAT.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "APELLIDO MATERNO"));


                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CIUDAD") == DBNull.Value)
                {
                    CB_CITY.Text = "";
                }
                else
                {
                    CB_CITY.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CIUDAD"));
                }


                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ESTADO") == DBNull.Value)
                {
                    CB_ESTADO.Text = "";
                }
                else
                {
                    CB_ESTADO.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ESTADO"));
                }

                R_SEX.EditValue = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "SEXO"));
                DT_FECHA_NAC.EditValue = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "FECHA NACIMIENTO"));


                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CURP") == DBNull.Value)
                {
                    TX_CURP.Text = "";
                }
                else
                {
                    TX_CURP.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CURP"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CALLE") == DBNull.Value)
                {
                    TX_CALLE.Text = "";
                }
                else
                {
                    TX_CALLE.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CALLE"));
                }


                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "Nº EXTERIOR") == DBNull.Value)
                {
                    TX_EXTERIOR.Text = "";
                }
                else
                {
                    TX_EXTERIOR.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "Nº EXTERIOR"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "Nº INTERIOR") == DBNull.Value)
                {
                    TX_INTERIOR.Text = "";
                }
                else
                {
                    TX_INTERIOR.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "Nº INTERIOR"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "REFERENCIA") == DBNull.Value)
                {
                    TX_CRUZ.Text = "";
                }
                else
                {
                    TX_CRUZ.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "REFERENCIA"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "COLONIA") == DBNull.Value)
                {
                    TX_COLONIA.Text = "";
                }
                else
                {
                    TX_COLONIA.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "COLONIA"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "TELEFONO") == DBNull.Value)
                {
                    TX_TELEFONO.Text = "";
                }
                else
                {
                    TX_TELEFONO.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "TELEFONO"));
                }

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CLASIFICACION") == DBNull.Value)
                {
                    CB_PREF.Text = "";
                }
                else
                {
                    CB_PREF.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CLASIFICACION"));
                }

                R_TIPO.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "TIPO");

                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value)
                {
                    TX_OBS.Text = "";
                }
                else
                {
                    TX_OBS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }



                C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BTN_PRINT_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.PrintDialog();
        }

        private void BTN_PREVIEW_ItemClick(object sender, ItemClickEventArgs e)
        {
            DGV_DATA.ShowRibbonPrintPreview();
        }

        private void HIDE_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            SHOW_PANEL.Enabled = true;
            HIDE_PANEL.Enabled = false;
        }

        private void SHOW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            SHOW_AUTOFILTER.Enabled = false;
            HIDE_AUTOFILTER.Enabled = true;
        }

        private void R_SEX_Leave(object sender, EventArgs e)
        {
            try
            {
                CURPLib.CURPLib CALC = new CURPLib.CURPLib();
                TX_CURP.Text = CALC.CURPCompleta(TX_PAT.Text, TX_MAT.Text, TX_NAME.Text, DT_FECHA_NAC.Text, Convert.ToString(R_SEX.EditValue), array_nombres[CB_ESTADO.SelectedIndex, 1]);
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
