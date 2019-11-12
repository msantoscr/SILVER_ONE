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


namespace SILVER_E.Admininistrador
{
    public partial class frm_city : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string usuario;
        Metodos mtd = new Metodos();
        frn_main_form frn_menu;
        public frm_city(string usu)
        {
            usuario = usu;
            InitializeComponent();
        }
        #region METODOS
        public void LIST_STATE()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_SILV_COUNTRY E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_LIST_ESTATE", mtd.conexion);
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

                    LBL_RESULT_STATE.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_STATE.Caption = Convert.ToString(Message.Value);

                }
                else
                {
                    LBL_RESULT_STATE.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_STATE.Caption = Convert.ToString(Message.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                DataTable DataT = new DataTable();
                da.Fill(DataT);
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_PAIS.DataSource = DataT;
                CB_PAIS.ValueMember = "ID_ESTATES";//EL VALOR QUE TENDRA
                CB_PAIS.DisplayMember = "ES_NAME";//EL VALOR QUE SE MOSTRARA
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
        public void LIST_VALUE_STATE()
        {
            try
            {
                //ESTABLECEMOS LA CONEXION A LA BASE DE DATOS
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_LIST_SILV_COUNTRY E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_VALUE_SILV_ESTATE_CITIES", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.Parameters.Add("@ID_ESTATE", SqlDbType.Int).Value=TXT_ID.Text;
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

                    LBL_RESULT_STATE.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_STATE.Caption = Convert.ToString(Message.Value);

                }
                else
                {
                    LBL_RESULT_STATE.Visibility = BarItemVisibility.Always;
                    LBL_RESULT_STATE.Caption = Convert.ToString(Message.Value);
                }

                SqlDataAdapter da = new SqlDataAdapter(mtd.comando);
                DataTable DataT = new DataTable();
                da.Fill(DataT);
                //VALUEMEMBER ES EL VALOR QUE TENDRA CADA QUE SE REALICE UNA SELECCION
                //DISPLAYMEMBER ES EL VALOR QUE SE MOSTRARA PERO, NO ES EL QUE TOMA EL VALOR UNA VEZ SELECCIONADO UN DATO DE LA LISTA
                CB_PAIS.DataSource = DataT;
                CB_PAIS.ValueMember = "ID_ESTATES";//EL VALOR QUE TENDRA
                CB_PAIS.DisplayMember = "ES_NAME";//EL VALOR QUE SE MOSTRARA
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
            TXT_NAME.ResetText();
            TXT_OBSERVATIONS.ResetText();
            C_ACTIVE_INACTIVE.CheckState = CheckState.Unchecked;
        }
        public void FILL_DATA()
        {
            try
            {
                mtd.ConectarBaseDatos();
                //SE EJECUTA UN NUEVO COMANDO SP_SILV_ESTATES_VIEW E INDICAMOS MEDIANTE With {.CommandType = CommandType.StoredProcedure} QUE SE TRATA DE UN PROCEDIMIENTO ALMACENADO
                mtd.comando = new SqlCommand("SP_SILV_CITIES_VIEW", mtd.conexion);
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
        #endregion

        private void frm_city_Load(object sender, EventArgs e)
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

        private void BTN_REFRESH_ItemClick(object sender, ItemClickEventArgs e)
        {
            LIST_STATE();
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TXT_NAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA CIUDAD","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    mtd.ConectarBaseDatos();
                    mtd.comando = new SqlCommand("SP_SILV_CITIES_INSERT",mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    //PARAMETROS
                    mtd.comando.Parameters.Add("@ID_ESTATES",SqlDbType.Int).Value =CB_PAIS.SelectedValue;
                    mtd.comando.Parameters.Add("@CI_NAME",SqlDbType.NVarChar,100).Value =TXT_NAME.Text;
                    if (TXT_OBSERVATIONS.Text=="")
                    {
                        mtd.comando.Parameters.AddWithValue("@CI_OBSERVATIONS", DBNull.Value);
                    }
                    else
                    {
                        mtd.comando.Parameters.Add("@CI_OBSERVATIONS",SqlDbType.NVarChar,200).Value =TXT_OBSERVATIONS.Text;
                    }
                    //SE ENVIA EL VALOR DEL CHECK ESTE ACTIVO O INACTIVO POR ESO SU PROPIEDAD CheckState
                    mtd.comando.Parameters.Add("@CI_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                    //SE ENVIA EL PARAMENTRO QUE CONTIENE EL VALOR DEL USUARIO CREADOR OBLIGATORIO EN ESTA APLICACION
                    mtd.comando.Parameters.Add("@CI_USER_CREATOR", SqlDbType.NVarChar, 100).Value = usuario;

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

                    XtraMessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    mtd.DesconectarBaseDatos();
                    CLEAN_FIELDS();
                    FILL_DATA();
                }
            }
        }

        private void BTN_CLEAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            CLEAN_FIELDS();  
        }

        private void BTN_SHOW_ItemClick(object sender, ItemClickEventArgs e)
        {
            FILL_DATA();
        }

        private void BTN_EDIT_ItemClick(object sender, ItemClickEventArgs e)
        {
            bool valida = false;
            if (TXT_ID.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (TXT_NAME.Text=="")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL NOMBRE DE LA CIUDAD","SISTEMA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                valida = true;
                return;
            }
            if (valida==true)
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR LA INFORMACION REQUERIDA PARA LA MODIFICACION DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA MODIFICAR EL REGISTRO DE LA CIUDAD?","SISTEMA",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_CITIES_EDIT", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //PARAMETROS
                        mtd.comando.Parameters.Add("@ID_CITY", SqlDbType.Int).Value =TXT_ID.Text;
                        mtd.comando.Parameters.Add("@ID_ESTATES", SqlDbType.Int).Value = CB_PAIS.SelectedValue;
                        mtd.comando.Parameters.Add("@CI_NAME", SqlDbType.NVarChar,100).Value = TXT_NAME.Text;
                        if (TXT_OBSERVATIONS.Text == "")
                        {
                            mtd.comando.Parameters.AddWithValue("@CI_OBSERVATIONS", DBNull.Value);
                        }
                        else
                        {
                            mtd.comando.Parameters.Add("@CI_OBSERVATIONS", SqlDbType.NVarChar, 200).Value = TXT_OBSERVATIONS.Text;
                        }
                        mtd.comando.Parameters.Add("@CI_ACTIVE_INACTIVE", SqlDbType.Int).Value = C_ACTIVE_INACTIVE.CheckState;
                        mtd.comando.Parameters.Add("@CI_USER_UPDATE", SqlDbType.NVarChar, 100).Value = usuario;
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
            
            if (TXT_ID.Text == "")
            {
                XtraMessageBox.Show("DEBE ESPECIFICAR EL IDENTIFICADOR DEL REGISTRO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                return;
            }
            else
            {
                if (XtraMessageBox.Show("¿DESEA ELIMINAR EL REGISTRO DE LA CIUDAD?","SISTEMA",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        mtd.ConectarBaseDatos();
                        mtd.comando = new SqlCommand("SP_SILV_CITIES_DELETE", mtd.conexion);
                        mtd.comando.CommandType = CommandType.StoredProcedure;
                        //PARAMETROS
                        mtd.comando.Parameters.Add("@ID_CITY",SqlDbType.Int).Value =TXT_ID.Text;
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

                        XtraMessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void G_DATA_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //LA CAJA DE TEXTO TXT_ID OBTENDRA EL VALOR DEL GRIDVIEW CON EL NOMBRE DE G_DATA DE SU COLUMNA "ID"
                TXT_ID.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ID"));
                TXT_NAME.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "CIUDAD"));
                if (G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES") == System.DBNull.Value)
                {
                    TXT_OBSERVATIONS.Text = "";
                }
                else
                {
                    TXT_OBSERVATIONS.Text = Convert.ToString(G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "OBSERVACIONES"));
                }
                //SE ASIGNA EL VALOR DE LA COLUMNA ACTIVO/INACTIVO AL CONTROL C_ACTIVE_INACTIVE.CheckState
                this.C_ACTIVE_INACTIVE.EditValue = G_DATA.GetRowCellValue(G_DATA.FocusedRowHandle, "ACTIVO/INACTIVO");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            {
                //EN CASO CONTARRIO QUE LA CAJA DE TEXTO SI CONTENGA ALGUN IDENTIFICADOR (ID)
                BTN_EDIT.Enabled = true; //HABILITAR BOTON MODIFICAR
                BTN_DELETE.Enabled = true; //HABILITAR BOTON ELIMINAR
                BTN_SAVE.Enabled = false; //DESABILITAR BOTON GUARDAR
                LIST_VALUE_STATE(); //EJECUTAMOS ESTE METODO PARA OBTENER EL VALOR DEL PAIS UNA VEZ QUE SE DE DOBLE CLIC SOBRE UN REGISTRO
            }
        }
    }
}