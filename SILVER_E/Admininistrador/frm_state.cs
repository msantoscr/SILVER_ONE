using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SILVER_E.Admininistrador
{
    public partial class frm_state : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string usuario;
        Metodos mtd = new Metodos();
        frn_main_form frn_menu;
        public frm_state(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }
        //METODO PARA LIMPIAR LAS CAJAS DE TEXTO Y CONTROLES DEL FORMULARIO
        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
        }
        //'METODO QUE EJECUTA UN PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_VIEW PARA LLENAR EL CONTROL GRIDCONTROL Y MOSTRAR LOS REGISTROS DE LA TABLA CORRESPONDIENTE
        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_SILV_ESTATES_VIEW", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_ESTATES_VIEW", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
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
                //INDICAMOS QUE LA FUENTE DE DATOS DEL CONTROL GRIDCONTROL SERA UN DATATABLE
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
                mtd.DesconectarBaseDatos();
            }
        }

        public void LIST_COUNTRY()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_SILV_COUNTRY E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_SILV_COUNTRY", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_LIST_SILV_COUNTRY
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_LIST_SILV_COUNTRY", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_SILV_COUNTRIES_VIEW SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)
                if (mtd.Rows > 0)
                {

                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value);

                }
                else
                {
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value);
                }

                mtd.adaptador.SelectCommand = mtd.comando;
                DataTable DataT = new DataTable();
                mtd.adaptador.Fill(DataT);
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_PAIS.DataSource = DataT;
                CB_PAIS.ValueMember = "ID_COUNTRY";//EL VALOR QUE TENDRA
                CB_PAIS.DisplayMember = "CO_NAME";//EL VALOR QUE SE MOSTRARA
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

        public void LIST_VALUE_COUNTRY()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_VALUE_SILV_COUNTRY_ESTATE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_VALUE_SILV_COUNTRY_ESTATE", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR
                mtd.comando.Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = TXT_ID.Text.Trim();

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_VALUE_SILV_COUNTRY_ESTATE", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();

                //SI EL RESULTADO DE LA CONSULTA ES MAYOR A CERO, ES DECIR QUE SE HAN ENCONTRADO REGISTROS DE LA EJCUCION DE LA CONSULTA ENTONCES
                //LE ASIGNAMOS EL TEXTO QUE OBTIENE DESDE OUTPUT A LA ETIQUETA DE LA BARRA INFERIOR DEL FORMULARIO Y LA HACEMOS VISIBLE
                //SI OBTIENE EL SEGUNDO O TECER VALOR DE OUTPUT DESDE EL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE SE ASGINA AL SIGUIENTE CODIGO LB_RESULT.Visibility = BarItemVisibility.Always
                //LB_RESULT.Caption = Convert.ToString(Message.Value)

                if (mtd.Rows > 0)
                {
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value);

                }
                else
                {
                    LB_RESULT_COUNTRY.Visibility = BarItemVisibility.Always;
                    LB_RESULT_COUNTRY.Caption = Convert.ToString(Message.Value);
                }

                //UTILIZAMOS LA PROPIEDAD SELECTCOMMAND PARA SELECCIONAR EL O LOS REGISTROS QUE COMPRENDAN LA CONSULTA DEL PROCEDIMIENTO ALMACENADO SP_VALUE_SILV_COUNTRY_ESTATE
                mtd.adaptador.SelectCommand = mtd.comando;
                //SE CREA UN NUEVO DATATABLE
                DataTable DataT = new DataTable();
                //INDICAMOS QUE EL ADAPTADOR DE LLENARA CON EL VALOR DE UN DATATABLE
                mtd.adaptador.Fill(DataT);
                //AL CONTROL CB_PAIS LE ASIGNAREMOS SU FUENTE DE DATOS A LOS QUE CONTENGA EL DATATABLE
                CB_PAIS.DataSource = DataT;
                CB_PAIS.ValueMember = "ID_COUNTRY"; //EL VALOR QUE TENDRA
                CB_PAIS.DisplayMember = "CO_NAME"; //EL VALOR QUE SE MOSTRARA
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
        private void frm_state_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //VERIFICAMOS SI EL VALOR DEL CAMPO DE NOMBRE DEL ESTADO NO ESTA VACIO PARA REGISTRARLO EN LA BD
            if (TXT_NAME.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTADO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    //CONECTAR  A LA BASE DE DATOS
                    mtd.ConectarBaseDatos();
                    //SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    mtd.comando = new SqlCommand("SP_SILV_ESTATES_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = CB_PAIS.SelectedValue;

                    //SE ENVIA EL PARAMETRO QUE CONTIENE EL NOMBRE DEL ESTADO DESDE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@ES_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;
                    //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@ES_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@ES_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }
                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@ES_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@ES_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;



                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_INSERT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_ESTATES_INSERT", connection)
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
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally{
                    //CERRAMOS LA CONEXION A LA BASE DE DATOS
                    mtd.DesconectarBaseDatos();
                    //LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS();
                    //LLENAMOS EL CONTROL GRIDCONTROL CON LA EJECUCION DEL METODO ENCARGADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO
                    FILL_DATA();
                }
            }
        }

        private void BTN_CLEAR_ItemClick(object sender, ItemClickEventArgs e)
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
            //ESTE CODIGO NOS OCULTA EL PANEL DE BUSQUEDA DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsFind.AlwaysVisible = false;
            //HABILITAMOS ESTE BOTON SHOW SHOW PANEL
            SHOW_PANEL.Enabled = true;
            //DESHABILITAMOS EL BOTON HIDE_PANEL
            HIDE_PANEL.Enabled = false;
        }

        private void VIEW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MUESTRA UNA FILA QUE PERMITE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            //SE DESABILITA EL BOTON VIEW_AUTOFILTER CON EL CODIGO Enabled = False
            VIEW_AUTOFILTER.Enabled = false;
            //SE HABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = True
            HIDE_AUTOFILTER.Enabled = true;
        }

        private void HIDE_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE OCULTA LA FILA QUE PERMIE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsView.ShowAutoFilterRow = false;
            //SE HABILITA EL BOTON DE VIEW_AUTOFILTER CON EL CODIGO Enabled = True
            VIEW_AUTOFILTER.Enabled = true;
            //SE DESABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = False
            HIDE_AUTOFILTER.Enabled = false;
        }

        private void DGV_DATA_DoubleClick(object sender, EventArgs e)
        {

        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                //LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE DE ESTADO"
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE DE ESTADO"));

                //ESTE CODIGO VERIFICA SI EL VALOR QUE CONTIENE LA COLUMNA  G_DATA.FocusedRowHandle, "OBSERVACIONES" NO SE ENCUENTRA EN UN VALOR NULL
                //DE TRATARSE DE UN VALOR VACIO ESTE NO ASIGNARA VALOR ALGUNO A LA CAJA DE TEXTO
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == System.DBNull.Value) {
                    TXT_OBSERVATIONS.Text = "";

                } else {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }

                //SE ASIGNA EL VALOR DE LA COLUMNA ACTIVO/INACTIVO AL CONTROL C_ACTIVE_INACTIVE.CheckState
                this.C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");


            }
            catch (Exception ex)
            {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TXT_ID_TextChanged(object sender, EventArgs e)
        {
            //IF LA CAJA DE TEXTO EN SU PROPIEDAD TEXT ES VACIO ENTONCES 
            if (TXT_ID.Text == "") {
                BTN_DELETE.Enabled = false; //DESBILITAR BOTON ELIMINAR
                BTN_EDIT.Enabled = false; //DESABILITAR BOTON MODIFICAR
                BTN_SAVE.Enabled = true; //HABILITAR BOTON GUARDAR
            } else { 
                //EN CASO CONTARRIO QUE LA CAJA DE TEXTO SI CONTENGA ALGUN IDENTIFICADOR (ID)
                BTN_EDIT.Enabled = true; //HABILITAR BOTON MODIFICAR
                BTN_DELETE.Enabled = true; //HABILITAR BOTON ELIMINAR
                BTN_SAVE.Enabled = false; //DESABILITAR BOTON GUARDAR
                LIST_VALUE_COUNTRY(); //EJECUTAMOS ESTE METODO PARA OBTENER EL VALOR DEL PAIS UNA VEZ QUE SE DE DOBLE CLIC SOBRE UN REGISTRO
         }
        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DECLARAMOS UNA VARIABLE QUE SE ENCARGA DE LA VALIDACION DE UN CAMPO VACIO INCIALIZADO EN FALSO
            //MODIFICACION DEL REGISTRO MEDIANTE UN IDENTIFICADOR =ID DE LA TABLA SQL
            bool VALIDA = false;
            //LOGICA:SI EL CAMPO TXT_ID QUE SE ENCARGA DE ALMACENAR EL TEXTO IDENTIFICADOR DEL REGISTRO ESTA VACIO ENTONCES
            if (TXT_ID.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                VALIDA = true;
                return;
            }
            if (TXT_NAME.Text == "") {
                //MOSTRAMOS UN MENSAJE INDICANDO QUE EL USUARIO DEBE ESPECIFICARLO
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTADO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                VALIDA = true; //SE ASIGNA EL VALOR DE TRUE A LA VARIABLE
                return;
            }
            //SI LA VALIDACION DE LOS IF ANTERIORES AMBOS SON VERDADEROS O AL MENOS UNO DE ELLOS ENTONCES

            if (VALIDA == true)
            {
                //SE MUESTRA UN MENSAJE INDICANDO QUE FALTA INFORMACION POR ESPECIFICAR PARA PROCEDER A LA MODIFICACION DEL REGISTRO
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {

                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_ESTATES_EDIT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@ID_ESTATES", SqlDbType.Int).Value = TXT_ID.Text;
                    mtd.comando.Parameters.Add("@ID_COUNTRY", SqlDbType.Int).Value = CB_PAIS.SelectedValue; //SE ENVIA EL VALOR DEL ID DEL PAIS MEDIANTE LA SELECCION DE UNA VALOR DE LA LISTA
                    mtd.comando.Parameters.Add("@ES_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text; //SE ENVIA EL VALOR DEL NOMBRE DEL ESTADO MEDIANTE LA CAJA DE TEXTO TXT_NAME

                    //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@ES_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@ES_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }

                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@ES_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO QUE MODIFICA OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@ES_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;


                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_EDIT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_ESTATES_EDIT", connection)
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_ESTATES_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS

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
                finally {
                    //CERRAMOS LA CONEION A LA BASE DE DATOS
                    mtd.DesconectarBaseDatos();
                    //LIMPIAMOS LOS CAMPOS
                    CLEAN_FIELDS();
                    //REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
                    FILL_DATA();
                }
            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //VERIFICAMOS SI EL CAMPO TXT_ID SE ENCUENTRA VACIO, SI ES TRUE=ESTA VACIO ENTONCES SE MUESTRA UN MENSAJE AL USUARIO INDICANDO QUE SE DEBE DE PROPORCIONAR PARA CONTINUAR CON LA ELIMINACION DEL REGISTRO
            if (TXT_ID.Text == "") {
                //EL USUARIO DEJO EL CAMPO VACIO
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            } else { //EN CASO CONTRARIO EL CAMPO NO ESTA VACIO

                //SE PREGUNTA AL USUARIO SI SE DESEA ELIMINAR EL REGISTRO DE LAS OPCIONES EL USUARIO PUEDE ELEGIR SI O NO
                //EL USUARIO PRESIONO NO, SE MUESTRA EL MENSAJE
                if (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL ESTADO?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    return;  //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
                } else { //EL USUARIO PRESIONO QUE SI DESEA ELIMINAR EL REGISTRO
                    try
                    {      //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                        mtd.ConectarBaseDatos();
                        //SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                        mtd.comando = new SqlCommand("SP_SILV_ESTATES_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                        //SE ENVIA EL VALOR DEL INDENTIFICADOR DEL REGISTRO Y ESTE LO ALMACENA LA CAJA DE TEXTO TXT_ID CON SU PROPIEDAD TEXT
                        mtd.comando.Parameters.Add("@ID_ESTATES", SqlDbType.Int).Value = TXT_ID.Text;

                        //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_ESTATES_DELETE
                        SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                        //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output;
                        //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        mtd.comando.Parameters.Add(Message);
                        //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL Command = New SqlCommand("SP_SILV_ESTATES_DELETE", connection)
                        mtd.Rows = mtd.comando.ExecuteNonQuery();
                        //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_ESTATES_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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
                    finally {
                        //CERRAMOS LA CONEXION A LA BASE DE DATOS
                        mtd.DesconectarBaseDatos();
                        //LIMPIAMOS LOS CAMPOS
                        CLEAN_FIELDS();
                        //REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
                        FILL_DATA();
                    }
                }
            }         
        }

        private void BTN_LIST_COUNTRY_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_COUNTRY();
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }
    }
}