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
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraBars;

namespace SILVER_E.Admininistrador
{
    public partial class frm_users : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        frn_main_form frn_menu;
        string usuario;
        //
        //
        //cambio 3
        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_PASSWORD.ResetText();
            TXT_USERNAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked; //A ESTE CONTROL SE LE ASIGNA EL VALOR DE UNCHECKED PARA INDICAR QUE SE TRATA DE UN VALOR 0

        }

        public void FILL_DATA()
        {

            try
            {

                mtd.ConectarBaseDatos();

                mtd.comando = new SqlCommand("SP_SILV_USERS_VIEW", mtd.conexion);
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

        public void LIST_USER_TYPE()
        {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_LIST_USER_TYPE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                mtd.comando.Parameters.Add(Message);
                mtd.Rows = mtd.comando.ExecuteNonQuery();

                if (mtd.Rows > 0)
                {
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always;
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always;
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_USER_TYPE
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_TYPE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
                CB_TYPE.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_TYPE.ValueMember = "ID_USER_TYPE"; //EL VALOR QUE TENDRA
                CB_TYPE.DisplayMember = "US_T_NAME_USER"; //EL VALOR QUE SE MOSTRARA


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

        public void LIST_VALUE_USER_TYPE()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BD
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_VALUE_USER_TYPE_USERS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;


                mtd.comando.Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = TXT_ID.Text.Trim();
                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_VALUE_USER_TYPE_USERS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always;
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value);

                }
                else
                {
                    LB_RESULT_TYPE_USER.Visibility = BarItemVisibility.Always;
                    LB_RESULT_TYPE_USER.Caption = Convert.ToString(Message.Value);
                }
                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_VALUE_USER_TYPE_USERS
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_TYPE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_TYPE.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_TYPE.ValueMember = "ID_USER_TYPE"; //EL VALOR QUE TENDRA
                CB_TYPE.DisplayMember = "US_T_NAME_USER"; //EL VALOR QUE SE MOSTRARA

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

        public void LIST_AGENTS()
        {
            try
            {
                //SE REALIZA LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_AGENTS E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_AGENTS", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_AGENTS", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //sI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {
                    LBL_RESULT_CLIENT.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_CLIENT.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    LBL_RESULT_CLIENT.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_CLIENT.Caption = Convert.ToString(Message.Value);
                }


                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_LIST_AGENTS
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_CLIENT LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
                CB_CLIENT.DataSource = DataT;
                CB_CLIENT.ValueMember = "ID_AGENTS";
                CB_CLIENT.DisplayMember = "AG_NAME_AGENT";
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

        public void LIST_FOLIOS_DISTINCT()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_DISTINCT_FOLIOS_USER E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_DISTINCT_FOLIOS_USER", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_DISTINCT_FOLIOS_USER
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_DISTINCT_FOLIOS_USER", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_LIST_DISTINCT_FOLIOS_USER SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //lB_RESULT.Caption = Convert.ToString(Message.Value)

                if (mtd.Rows > 0)
                {
                    barStaticItem1.Visibility = BarItemVisibility.Always;
                    barStaticItem1.Caption = Convert.ToString(Message.Value);
                }
                else
                {
                    barStaticItem1.Visibility = BarItemVisibility.Always;
                    barStaticItem1.Caption = Convert.ToString(Message.Value);
                }

                //CREAMOS UN ADAPTADOR PARA EL COMANDO
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_SERIE LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE

                CB_SERIE.DataSource = DataT;
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_SERIE.ValueMember = "ID_FOLIOS"; //EL VALOR QUE TENDRA
                CB_SERIE.DisplayMember = "FO_NAME_SERIE_FOLIO"; //EL VALOR QUE SE MOSTRARA

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
        public frm_users(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        private void frm_users_Load(object sender, EventArgs e)
        {
            FILL_DATA(); //SE LLAMA AL METODO QUE LLENA LA TABLA DE LOS REGISTROS EXISTENTES EN EL SISTEMA
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE DECLARA UNA VARIABLE DE TIPO BOOLEAN INICIALIZADA EN FALSE PARA LA VALIDACION DEL LOS CAMPOS
            bool VALIDA = false;
            //LOGICA SI AL COMPARAR EL VALOR CONTENIDO EN ALGUNA DE LAS CAJAS DE TEXTO EN SU PROPIEDAD TEXT ES IGUAL A UN VALOR VACIO ENTONCES MOSTRAR UN MENSAJE INDICANDO QUE HACE FALTA UN VALOR
            //SE ASIGNA A LA VARIABLE VALIDA EL VALOR DE TRUE PARA LA ULTIMA VALIDACION ANTES DEL REGISTRO

            if (TXT_NAME.Text == "")
            { //SI EL CAMPO TXT_NAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
              //MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
            }

            if (TXT_USERNAME.Text == "")
            { //SI EL CAMPO TXT_USERNAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
                XtraMessageBox.Show("DEBE ESPECIFICAR SU NOMBRE DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
            }


            if (TXT_PASSWORD.Text == "")
            { //SI EL CAMPO TXT_PASSWORD EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR MENSAJE INDICANDO QUE FALTA LLENAR ESTE CAMPO
                XtraMessageBox.Show("DEBE ESPECIFICAR SU CONTRASEÑA DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_SAVE_ItemClick
            }

            //SI ALGUNO DE LOS CAMPOS ANTERIORES SE ENCUENTRA VACIO ENTONCES ENTRA A ESTA VALIDACION DONDE DEBE ESPECIFICARSE TODA LA INFORMACION
            if (VALIDA == true)
            {
                //MOSTRAR MENSAJE DE ESPECIFICACION DE DATOS
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL
            }
            else
            {
                try
                {
                    //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                    mtd.ConectarBaseDatos();
                    //SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    mtd.comando = new SqlCommand("SP_SILV_USERS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;
                    //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                    mtd.comando.Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = CB_TYPE.SelectedValue; //SE ENVIA EL VALOR DEL TIPO DE USUARIO DESDE LA SELECCION DEL VALOR DE LA LISTA
                    mtd.comando.Parameters.Add("@ID_AGENTS", SqlDbType.Int).Value = CB_CLIENT.SelectedValue; //SE ENVIA EL VALOR DEL AGENTE DESDE LA SELECCION DEL VALOR DE LA LISTA
                    mtd.comando.Parameters.Add("@ID_FOLIOS", SqlDbType.Int).Value = CB_SERIE.SelectedValue; //SE ENVIA EL VALOR DEL FOLIO DESDE LA SELECCION DEL VALOR DE LA LISTA
                    mtd.comando.Parameters.Add("@US_NAME", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text; //SE ENVIA EL VALOR DEL  NOMBRE DEL USUARIO DESDE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@US_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text; //SE ENVIA EL VALOR DEL USERNAME DEL USUARIO DESDE LA CAJA DE TEXTO TXT_USERNAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@US_PASSWORD", SqlDbType.NVarChar, 100).Value = TXT_PASSWORD.Text; //SE ENVIA EL VALOR DE LA CONTRASEÑA DESDE LA CAJA DE TEXTO TXT_PASSWORD EN SU PROPIEDAD TEXT

                    //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@US_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@US_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }
                    
                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@US_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@US_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;



                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_INSERT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_INSERT", connection)
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

                    //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //CERRAMOS LA CONEXION A LA BASE DE DATOS
                    mtd.DesconectarBaseDatos();
                    //LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS();
                    //LLENAMOS EL CONTROL GRIDCONTROL CON LA EJECUCION DEL METODO ENCARGADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                    FILL_DATA();
                }
            }
        }

        private void BTN_REFRESH_TYPE_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_USER_TYPE(); //LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS TIPOS DE USUARIO

        }

        private void BTN_REFRESH_CLIENT_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_AGENTS(); //LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS CLIENTES/VENDEDOR

        }

        private void BTN_REFRESH_FOLIOS_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_FOLIOS_DISTINCT(); //LLAMAMOS AL METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO QUE ACTUALIZA LA LISTA DE LOS FOLIOS

        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE DECLARA UNA VARIABLE DE TIPO BOOLEAN INICIALIZADA EN FALSE PARA LA VALIDACION DEL LOS CAMPOS
            bool VALIDA = false;
            //LOGICA SI AL COMPARAR EL VALOR CONTENIDO EN ALGUNA DE LAS CAJAS DE TEXTO EN SU PROPIEDAD TEXT ES IGUAL A UN VALOR VACIO ENTONCES MOSTRAR UN MENSAJE INDICANDO QUE HACE FALTA UN VALOR
            //SE ASIGNA A LA VARIABLE VALIDA EL VALOR DE TRUE PARA LA ULTIMA VALIDACION ANTES DEL REGISTRO


            if (TXT_ID.Text == "")
            { //SI EL CAMPO TXT_ID EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            }


            if (TXT_NAME.Text == "")
            { //SI EL CAMPO TXT_NAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA PERSONA PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            }

            if (TXT_USERNAME.Text == "")
            { //SI EL CAMPO TXT_USERNAME EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
                XtraMessageBox.Show("DEBE ESPECIFICAR SU NOMBRE DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            }


            if (TXT_PASSWORD.Text == "")
            { //SI EL CAMPO TXT_PASSWORD EN SU PROPIEDAD TEXT ES UN VALOR VACIO ENTONCES
                //MOSTRAR UN MENSAJE INDICANDO QUE FALTA UN VALOR POR ESPECIFICAR
                XtraMessageBox.Show("DEBE ESPECIFICAR SU CONTRASEÑA DE ACCESO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE VALIDA
                return; //SE CANCELA LA OPERACION ACTUAL  Private Sub BTN_EDIT_ItemClick
            }

            //SI ALGUNO DE LOS CAMPOS ANTERIORES SE ENCUENTRA VACIO ENTONCES ENTRA A ESTA VALIDACION DONDE DEBE ESPECIFICARSE TODA LA INFORMACION
            if (VALIDA == true)
            {
                //MOSTRAR MENSAJE DE ESPECIFICACION DE DATOS
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA EL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // SE CANCELA LA OPERACION ACTUAL Private Sub BTN_EDIT_ItemClick
            }
            else
            { //EN CASO CONTRARIO QUE NO FALTE INFORMACION POR ESPECIFICAR ENTONCES PREGUNTAR SI SE DESEA MODIFICAR EL REGISTRO, SI EL USUARIO PRESIONA NO ENTONCES
                try
                {
                    mtd.ConectarBaseDatos();
                    //SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_EDIT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    mtd.comando = new SqlCommand("SP_SILV_USERS_EDIT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;
                    //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                    mtd.comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = TXT_ID.Text;
                    mtd.comando.Parameters.Add("@ID_USER_TYPE", SqlDbType.Int).Value = CB_TYPE.SelectedValue; //SE ENVIA EL PARAMETRO ID_USER_TYPE MEDIANTE LA SELECCION DEL VALOR DE LA LISTA TIPO DE USUARIO
                    mtd.comando.Parameters.Add("@US_NAME", SqlDbType.NVarChar, 200).Value = TXT_NAME.Text; //SE ENVIA EL PARAMETRO US_NAME MEDIANTE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@US_USERNAME", SqlDbType.NVarChar, 50).Value = TXT_USERNAME.Text; //SE ENVIA EL PARAMETRO US_USERNAME MEDIANTE LA CAJA DE TEXTO TXT_USERNAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@US_PASSWORD", SqlDbType.NVarChar, 100).Value = TXT_PASSWORD.Text; //SE ENVIA EL PARAMETRO US_PASSWORD MEDIANTE LA CAJA DE TEXTO TXT_PASSWORD EN SU PROPIEDAD TEXT


                    //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@US_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@US_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }

                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@US_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMETRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@US_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_EDIT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_EDIT", connection)
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USERS_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS

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
                    //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    //CERRAMOS LA CONEXION A LA BASE DE DATOS
                    mtd.DesconectarBaseDatos();
                    //LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS();
                    //LLENAMOS EL CONTROL GRIDCONTROL CON LA EJECUCION DEL METODO ENCARGADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                    FILL_DATA();
                }
            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE VERIFICA QUE ANTES DE REALIZAR UNA ELIMINACION DE UN REGISTRO ESTE COINCIDA CON EL QUE SE REQUIERE ELIMINAR Y ESTO SE REALIZA MEDIANTE EL VALOR DE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT

            if (TXT_ID.Text == "")
            { //SI LA CAJA DE TEXTO TXT_ID ESTA VACIA ENTONCES
              //SE MUESTRA UN MENSAJE INDICANDO QUE SE DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO A ELIMINAR
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            }
            else
            { //EN CASO CONTRARIO DE QUE SI SE HAYA ESPECIFICADO EL IDENTIFICADOR DEL REGISTRO
              //SE PREGUNTA AL USUARIO SI SE DESEA ELIMINAR EL REGISTRO, SI EL USUARIO PRESIONO EL BOTON NO ENTONCES
                if (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL USUARIO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
                }
                else
                {
                    try
                    {
                        //SE ESTABLECE LA CONEXION CON LA BASE DE DATOS
                        mtd.ConectarBaseDatos();
                        //SE EJECUTA UN NUEVO COMANDO SP_SILV_USERS_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                        mtd.comando = new SqlCommand("SP_SILV_USERS_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                        mtd.comando.Parameters.Add("@ID_USER", SqlDbType.Int).Value = TXT_ID.Text; //SE ESPECIFICA EL VALOR DEL PARAMETRO ID_USER MEDIANTE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT

                        //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_USERS_DELETE
                        SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                        //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output;
                        //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        mtd.comando.Parameters.Add(Message);
                        //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_USERS_DELETE", connection)
                        mtd.Rows = mtd.comando.ExecuteNonQuery();
                        //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_USERS_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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
                        //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                        XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        //CERRAMOS LA CONEXION A LA BASE DE DATOS
                        mtd.DesconectarBaseDatos();
                        //LIMPIAMOS LOS CAMPOS
                        CLEAN_FIELDS();
                        //LLENAMOS EL CONTROL GRIDCONTROL CON LA EJECUCION DEL METODO ENCARGADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                        FILL_DATA();
                    }
                }

            }
        }

        private void TXT_ID_TextChanged(object sender, EventArgs e)
        {
            //IF LA CAJA DE TEXTO EN SU PROPIEDAD TEXT ES VACIO ENTONCES
            if (TXT_ID.Text == "")
            {
                BTN_DELETE.Enabled = false;//DESBILITAR BOTON ELIMINAR
                BTN_EDIT.Enabled = false; //DESABILITAR BOTON MODIFICAR
                BTN_SAVE.Enabled = true; //HABILITAR BOTON GUARDAR
            }
            else
            { //EN CASO CONTARRIO QUE LA CAJA DE TEXTO SI CONTENGA ALGUN IDENTIFICADOR (ID)
                BTN_EDIT.Enabled = true; //HABILITAR BOTON MODIFICAR
                BTN_DELETE.Enabled = true; //HABILITAR BOTON ELIMINAR
                BTN_SAVE.Enabled = false; //DESABILITAR BOTON GUARDAR
                LIST_VALUE_USER_TYPE(); //EJECUTAMOS ESTE METODO PARA OBTENER EL VALOR DEL TIPO DE USUARIO UNA VEZ QUE SE DA DOBLE CLIC SOBRE UN REGISTRO
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
            //ESTE CODIGO NOS MUESTRA UN PANEL DE BUSQUEDA DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsFind.AlwaysVisible = true;
            //DESABILITAMOS ESTE BOTON SHOW_PANEL
            SHOW_PANEL.Enabled = false;
            //HABILITAMOS EL BOTON HIDE_PANEL
            HIDE_PANEL.Enabled = true;
        }

        private void HIDE_PANEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ESTE CODIGO NOS OCULTA EL PANEL DE BUSQUEDA DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            //HABILITAMOS ESTE BOTON SHOW_PANEL
            SHOW_PANEL.Enabled = true;
            //DESABILITAMOS EL BOTON HIDE_PANEL
            HIDE_PANEL.Enabled = false;
        }

        private void SHOW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MUESTRA UNA FILA QUE PERMITE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            //SE DESABILITA EL BOTON VIEW_AUTOFILTER CON EL CODIGO Enabled = False
            SHOW_AUTOFILTER.Enabled = false;
            //sE HABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = True
            HIDE_AUTOFILTER.Enabled = true;
        }

        private void DGV_DATA_DoubleClick(object sender, EventArgs e)
        {

        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try {
                //LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                //LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE DEL USUARIO"
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE DEL USUARIO"));
                //LA CAJA DE TEXTO TXT_USERNAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "USUARIO"
                TXT_USERNAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "USUARIO"));
                //LA CAJA DE TEXTO TXT_PASSWORD OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "USUARIO"
                TXT_PASSWORD.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CONTRASEÑA"));


                //ESTE CODIGO VERIFICA SI EL VALOR QUE CONTIENE LA COLUMNA  G_DATA.FocusedRowHandle, "OBSERVACIONES" NO SE ENCUENTRA EN UN VALOR NULL
                //DE TRATARSE DE UN VALOR VACIO ESTE NO ASIGNARA VALOR ALGUNO A LA CAJA DE TEXTO
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value) {
                    TXT_OBSERVATIONS.Text = "";
                }
                else {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }
                //SE ASIGNA EL VALOR DE LA COLUMNA ACTIVO/INACTIVO AL CONTROL C_ACTIVE_INACTIVE.CheckState
                this.C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");



            }
            catch (Exception ex) {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}