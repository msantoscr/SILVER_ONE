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
    public partial class frm_status_clients : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        public frm_status_clients(string usu)
        {
            InitializeComponent();
            usuario = usu;
        }

        public void CLEAN_FIELDS()
        {
            TXT_ID.ResetText();
            TXT_NAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
        }

        public void FILL_DATA()
        {
            try
            {
                //ESTABLECER COENXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_SILV_STATUS_CLIENTS_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_SILV_STATUS_CLIENTS_VIEW", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_STATUS_CLIENTS_VIEW
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                mtd.comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_STATUS_CLIENTS_VIEW", connection)
                mtd.Rows = mtd.comando.ExecuteNonQuery();
                //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_STATUS_CLIENTS_VIEW SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS

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
                //FINALMENTE SE CIERRA LA CONEXION A LA BASE DE DATOS CON ESTE METODO QUE PROVIENE DESDE MetodosClases
                mtd.DesconectarBaseDatos();
            }
        }
        private void frm_status_clients_Load(object sender, EventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SE VERIFICA MEDIANTE UN IF SI LA CAJA DE TEXTO TXT_NAME SE ENCUENTRA VACIA AL MOMENTO DE ENVIAR A GUARDAR EL REGISTRO ESTO PARA EVITAR QUE SE ENVIE UN VALOR NULL
            if (TXT_NAME.Text == "")
            { //SI ESTA VACIA ENTONCES
                //MOSTRAR UN MENSAJE INDICANDO QUE FALTA ESPECIFICAR EL NOMBRE DEL ESTATUS
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTATUS PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL
            }
            else
            { //EN CASO DE QUE NO ESTE VACIA ENTONCES
                try
                {
                    //SE ESTABLECE LA CONEXION CON LA BASE DE DATOS
                    mtd.ConectarBaseDatos();
                    //SE EJECUTA UN NUEVO COMANDO SP_SILV_STATUS_CLIENTS_INSERT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                    mtd.comando = new SqlCommand("SP_SILV_STATUS_CLIENTS_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;
                    //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                    //SE ENVIA EL PARAMETRO ST_NAME MEDIANTE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                    mtd.comando.Parameters.Add("@ST_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;


                    //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                    //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                    if (TXT_OBSERVATIONS.Text == "")
                    {
                        mtd.comando.Parameters.AddWithValue("@ST_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@ST_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                    }
                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@ST_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@ST_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;
                    //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_STATUS_CLIENTS_INSERT
                    SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                    //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                    Message.Direction = ParameterDirection.Output;
                    //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                    mtd.comando.Parameters.Add(Message);
                    //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_STATUS_CLIENTS_INSERT", connection)
                    mtd.Rows = mtd.comando.ExecuteNonQuery();
                    //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_STATUS_CLIENTS_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool valida = false;

            if (TXT_ID.Text == "")
            {

                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true;
                return;
            }

            if (TXT_NAME.Text == "")
            { //SI LA CAJA DE TEXTO TXT_NAME SE ENCUENTRA VACIA ENTONCES
              //SE MUESTRA UN MENSAJE INDICANDO QUE FALTA LA INFORMACION DE ESTE CAMPO ANTES DEL DE LA MODIFICACION DEL REGISTRO
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DEL ESTATUS PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valida = true; //SE ESTABLECE LA VARIABLE DE VALIDACION EN TRUE PARA UNA SEGUNDA VALIDACION ANTES DE LA MODFICACION DEL REGISTRO
                return; //SE CANCELA LA OPERACION  Private Sub BTN_EDIT_ItemClick
            }
            //SI ALGUNA DE LAS CONDICIONES ANTERIORES RESULTARA VERDADERA (VALIDA=TRUE) ENTONCES ENTRA EN FUNCION ESTA VALIDACION ANTES DE LA MODIFICACION
            if (valida == true)
            {
                //SE MUESTRA UN MENSAJE QUE INDICA QUE SE DEBE ESPECIFICAR LA INFORMACION DEL REGISTRO DEPENDIENDO EL DATO FALTANTE
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_EDIT_ItemClick
            }
            else
            { //EN CASO CONTRARIO QUE SE HAYA ESPECIFICADO TODA LA INFORMACION ENTONCES SE PREGUNTA AL USUARIO SI DESEA MODIFICAR EL REGISTRO
              //SI EL USUARIO PRESIONA LA OPCION NO ENTONCES
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DEL ESTATUS DE CLIENTE?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_EDIT_ItemClick
                }
                else
                { //EL USUARIO PRESIONO LA OPCION SI
                    try
                    {
                        //SE ESTABLECE LA CONEXION A LA BASE DE DATOS
                        mtd.ConectarBaseDatos();
                        //SE EJECUTA UN NUEVO COMANDO SP_SILV_STATUS_CLIENTS_EDIT E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                        mtd.comando = new SqlCommand("SP_SILV_STATUS_CLIENTS_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                        //SE ENVIA EL PARAMETRO ID_STATUS_CLIENT MEDIANTE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT
                        mtd.comando.Parameters.Add("@ID_STATUS_CLIENT", SqlDbType.Int).Value = TXT_ID.Text;
                        //SE ENVIA EL PARAMETRO NOMBRE DEL ESTATUS DE CLIENTE DESDE LA CAJA DE TEXTO TXT_NAME EN SU PROPIEDAD TEXT
                        mtd.comando.Parameters.Add("@ST_NAME", SqlDbType.NVarChar, 100).Value = TXT_NAME.Text;

                        //SE VERIFICA SI EL USUARIO HA ESCRITO UN VALOR DENTRO DE LA CAJA  DE TEXTO OBSERVACIONES
                        //SI NO SE ENVIA NINGUN DATO ESTE SE PASA COMO UN VALOR NULO HACIA LA TABLA
                        if (TXT_OBSERVATIONS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@ST_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@ST_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                        }
                        //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                        mtd.comando.Parameters.Add("@ST_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO QUE MODIFICA OBLIGATORIO EN ESTA APLICACION
                        mtd.comando.Parameters.Add("@ST_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;

                        //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_STATUS_CLIENTS_EDIT
                        SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                        //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output;
                        //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        mtd.comando.Parameters.Add(Message);
                        ///LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_STATUS_CLIENTS_EDIT", connection)
                        mtd.Rows = mtd.comando.ExecuteNonQuery();
                        //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_STATUS_CLIENTS_EDIT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS

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
                        //CERRAMOS LA CONEION A LA BASE DE DATOS
                        mtd.DesconectarBaseDatos();
                        //LIMPIAMOS LOS CAMPOS
                        CLEAN_FIELDS();
                        //REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
                        FILL_DATA();
                    }
                }
            }
        }

        private void BTN_DELETE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TXT_ID.Text == "")
            { //SI EL CAMPO ESTA VACIO ENTONCES
              //SE MUESTRA UN MENSAJE INDICANDO QUE HACE FALTA EL IDENTIFICADOR DEL REGISTRO
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO PARA CONTINUAR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
            }
            else
            { //EN CASO CONTRARIO EL CAMPO NO SE ENCUENTRA VACIO ENTONCES SE MUESTRA UN MENSAJE AL USUARIO SI DESEA ELIMINAR EL REGISTRO
              //SI EL USUARIO PRESIONA LA OPCION NO ENTONCES
                if (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DEL ESTATUS DE CLIENTE?", "SISTEMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return; //SE CANCELA LA OPERACION ACTUAL Private Sub BTN_DELETE_ItemClick
                }
                else
                { //EN CASO CONTRARIO EL USUARIO PRESIONO LA OPCION SI
                    try
                    {
                        //SE REALIZA LA CONEXION A LA BASE DE DATOS
                        mtd.ConectarBaseDatos();
                        //SE EJECUTA UN NUEVO COMANDO SP_SILV_STATUS_CLIENTS_DELETE E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                        mtd.comando = new SqlCommand("SP_SILV_STATUS_CLIENTS_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //INDICAMOS QUE ESTE COMANDO TENDRA PARAMETROS ADICIONALES PARA PODER EJECUTARSE Y DE SER POSIBLE RETORNAR UN VALOR

                        //SE ENVIA EL PARAMETRO IDENTIFICADOR DEL REGISTRO ID_STATUS_CLIENT DESDE EL TEXTO QUE CONTIENE LA CAJA DE TEXTO TXT_ID EN SU PROPIEDAD TEXT
                        mtd.comando.Parameters.Add("@ID_STATUS_CLIENT", SqlDbType.Int).Value = TXT_ID.Text;

                        //DECLARAMOS UNA VARIABLE DE TIPO SQLPARAMETER CON EL NOMBRE DEL @MENSAJE DE TIPO NVARCHAR Y LONGITUD 200, MISMO QUE SE DECLARO EN EL CUERPO DEL PROCEDIMIENTO ALMACENADO SP_SILV_STATUS_CLIENTS_DELETE
                        SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                        //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                        Message.Direction = ParameterDirection.Output;
                        //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                        mtd.comando.Parameters.Add(Message);
                        //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_STATUS_CLIENTS_DELETE", connection)
                        mtd.Rows = mtd.comando.ExecuteNonQuery();
                        //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_STATUS_CLIENTS_DELETE SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
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
                        //CERRAMOS LA CONEION A LA BASE DE DATOS
                        mtd.DesconectarBaseDatos();
                        //LIMPIAMOS LOS CAMPOS
                        CLEAN_FIELDS();
                        //REFRESCAMOS LA VISTA DE LOS REGISTROS LLAMANDO EL METODO ENCARGADO DE EJECUTAR ESTE PROCEDIMIENTO ALMACENADO
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
                BTN_DELETE.Enabled = false; //DESBILITAR BOTON ELIMINAR
                BTN_EDIT.Enabled = false; //DESABILITAR BOTON MODIFICAR
                BTN_SAVE.Enabled = true; //HABILITAR BOTON GUARDAR
            }
            else
            { //EN CASO CONTARRIO QUE LA CAJA DE TEXTO SI CONTENGA ALGUN IDENTIFICADOR (ID)
                BTN_EDIT.Enabled = true; //HABILITAR BOTON MODIFICAR
                BTN_DELETE.Enabled = true; //HABILITAR BOTON ELIMINAR
                BTN_SAVE.Enabled = false; //DESABILITAR BOTON GUARDAR

            }
        }

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try {
                //LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                //LA CAJA DE TEXTO TXT_NAME OBTENDRA EL VALIR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "NOMBRE STATUS"
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "NOMBRE STATUS"));


                //ESTE CODIGO VERIFICA SI EL VALOR QUE CONTIENE LA COLUMNA  G_DATA.FocusedRowHandle, "OBSERVACIONES" NO SE ENCUENTRA EN UN VALOR NULL
                //DE TRATARSE DE UN VALOR VACIO ESTE NO ASIGNARA VALOR ALGUNO A LA CAJA DE TEXTO
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == DBNull.Value) {
                    TXT_OBSERVATIONS.Text = "";
                }
                else {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }

                //SE ASIGNA EL VALOR DE LA COLUMNA ACTIVO/INACTIVO AL CONTROL C_ACTIVE_INACTIVE.CheckState
                C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");

            }
            catch (Exception ex) {
                //SE MUESTRA UN MENSAJE DE ERROR INDICANDO QUE ALGO DENTRO DEL CODIGO TRY ESTA MAL
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

        private void VIEW_AUTOFILTER_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MUESTRA UNA FILA QUE PERMITE EL AUTOFILTRO DE REGISTROS DE NUESTRO CONTROL GRIDCONTROL
            this.G_DATA.OptionsView.ShowAutoFilterRow = true;
            //SE DESABILITA EL BOTON VIEW_AUTOFILTER CON EL CODIGO Enabled = False
            VIEW_AUTOFILTER.Enabled = false;
            //'SE HABILITA EL BOTON HIDE_AUTOFILTER CON EL CODIGO Enabled = True
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

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_CLEAN_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLEAN_FIELDS();
        }
    }
}