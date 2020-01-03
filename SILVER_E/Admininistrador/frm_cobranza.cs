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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace SILVER_E.Admininistrador
{
    public partial class frm_cobranza : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Metodos mtd = new Metodos();
        string usuario;
        DataSet dPartidas = new DataSet();
        int result;
        string folioRemision, folioDevo;
        string nombreUser;
        string nombreSucursal;
        string direccionSucursal;
        string rfcSucursal;

        //DataTable table = new DataTable("Table");
        public frm_cobranza(string usu)
        {
            usuario = usu;
            InitializeComponent();
            dgv_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            //table.Columns.Add("CANTIDAD", Type.GetType("System.Int32"));
            //table.Columns.Add("ID_ARTICULO", Type.GetType("System.String"));
            //table.Columns.Add("CANTIDAD_REGRESADA", Type.GetType("System.Int32"));
            //table.Columns.Add("DIFERENCIA", Type.GetType("System.String"));
            //table.Columns.Add("DESCRIPCION", Type.GetType("System.String"));
            //table.Columns.Add("DESCUENTO", Type.GetType("System.String"));
            //table.Columns.Add("PRECIO_PUBLICO", Type.GetType("System.String"));
            //table.Columns.Add("PRECIO_DESCUENTO", Type.GetType("System.String"));
            //table.Columns.Add("IMPORTE", Type.GetType("System.String"));

            //dgv_data.DataSource = table;
            txt_devolucion.Text = "0.0";
            string fecha = DateTime.Today.ToString("dd/MM/yyyy");
            TXT_FECHA_ACTUAL.Text = fecha;
            FILL_DATA();
            DATOS_COMPLEMENTA();
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
                TXT_PEDIDO.Focus();

            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message,"ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void TXT_PEDIDO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (TXT_ID_CLIENT.Text != "" || TXT_ID_CLIENT.Text != null)
                {

                    mtd.llenarDetalleFolio(dgv_data, TXT_PEDIDO.Text);
                    ventaTotal();
                    if (txt_descuento.Text == "30%") {
                        Double descuento = 0.30;
                        string total1 = txt_total.Text;
                        string phrase = total1.Replace(",","");
                        int total = Convert.ToInt32(phrase);
                        Double SUMATORIA = Convert.ToDouble(total * descuento);
                        TXT_TOTAL_DESCUENTO.Text = Convert.ToString(SUMATORIA);
                    } else if (txt_descuento.Text == "35%") {
                        Double descuento = 0.35;
                        string total1 = txt_total.Text;
                        string phrase = total1.Replace(",", "");
                        int total = Convert.ToInt32(phrase);
                        Double SUMATORIA = Convert.ToDouble(total * descuento);
                        TXT_TOTAL_DESCUENTO.Text = Convert.ToString(SUMATORIA);
                    } else if (txt_descuento.Text == "50%") {
                        Double descuento = 0.50;
                        string total1 = txt_total.Text;
                        string phrase = total1.Replace(",", "");
                        int total = Convert.ToInt32(phrase);
                        Double SUMATORIA = Convert.ToDouble(total * descuento);
                        TXT_TOTAL_DESCUENTO.Text = Convert.ToString(SUMATORIA);
                    }
                    
                    calculartabla();
                    calculartablainicio();
                    obtenerTotalFinal();
                    sumatorias();
                    TXT_ARTICULO.Focus();
                }
                else
                {
                    XtraMessageBox.Show("Ocurrio un error al consultar la nota, al parecer no tiene un cliente!!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void ventaTotal() {
            try
            {
                mtd.ConectarBaseDatos();
                mtd.comando = new SqlCommand("SP_OBTENER_TOTALXFOLIO", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = TXT_PEDIDO.Text;
                mtd.lector = mtd.comando.ExecuteReader();
                if (mtd.lector.Read())
                {

                    txt_total.Text = Convert.ToString(mtd.lector["TOTAL"]);
                   
                    string tvta = Convert.ToString(mtd.lector["TOTAL"]);
                    string phrase = tvta.Replace(",", "");
                    if (Convert.ToInt32(phrase) >= 1000 && Convert.ToInt32(phrase) <= 1699)
                    {
                        txt_descuento.Text = "30%";
                    }
                    else if (Convert.ToInt32(phrase) >= 1700 && Convert.ToInt32(phrase) <= 4999)
                    {
                        txt_descuento.Text = "35%";
                    }
                    else if(Convert.ToInt32(phrase) >=5000){
                        txt_descuento.Text = "50%";

                    }
                    
                    txt_importe_nota.Text = Convert.ToString(mtd.lector["TOTAL_VENTA"]);
                    txtVentaOriginal.Text = Convert.ToString(mtd.lector["TOTAL_VENTA"]);
                    
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

        private void TXT_ARTICULO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Double devo = 0.0;
                foreach (DataGridViewRow Row in dgv_data.Rows)
                {

                    if (Convert.ToString(Row.Cells["ID_ARTICULO"].Value) == TXT_ARTICULO.Text)
                    {
                        if (Convert.ToInt32(Row.Cells["CANTIDAD_REGRESADA"].Value) != 0)
                        {
                            int CANTIDAD = Convert.ToInt32(Row.Cells["CANTIDAD_REGRESADA"].Value);
                            int CANTIDAD_MENOS = Convert.ToInt32(Row.Cells["CANTIDAD"].Value);
                            if (CANTIDAD_MENOS == 0)
                            {
                                XtraMessageBox.Show("No puede devolver este articulo supero el limite!", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                                TXT_ARTICULO.Text = string.Empty;
                                return;
                                
                            }
                            Row.Cells["CANTIDAD_REGRESADA"].Value = CANTIDAD + 1;
                            Row.Cells["CANTIDAD"].Value = CANTIDAD_MENOS - 1;
                            int cr =Convert.ToInt32(Row.Cells["CANTIDAD_REGRESADA"].Value);
                            Double pb = Convert.ToDouble(Row.Cells["PRECIO_PUBLICO"].Value);
                            Row.Cells["DIFERENCIA"].Value = Convert.ToString(pb * cr);
                        }
                        else
                        {
                            int CANTIDAD = Convert.ToInt32(Row.Cells["CANTIDAD"].Value);
                            int CANTIDAD_REGRESADA = 1;
                            Row.Cells["CANTIDAD_REGRESADA"].Value = CANTIDAD_REGRESADA;
                            Row.Cells["CANTIDAD"].Value = CANTIDAD - 1;

                            int cr = Convert.ToInt32(Row.Cells["CANTIDAD_REGRESADA"].Value);
                            Double pb = Convert.ToDouble(Row.Cells["PRECIO_PUBLICO"].Value);
                            Row.Cells["DIFERENCIA"].Value = Convert.ToString(pb * cr);
                        }
                    }
                    devo = devo + Double.Parse(Row.Cells["DIFERENCIA"].Value.ToString());
                }
                txt_devolucion.Text = Convert.ToString(devo);
                obtenerTotalFinal();
                CALCULAR();
                sumatorias();
                calculartabla();
                TXT_ARTICULO.Text = string.Empty;
            }
        }

        public void sumatorias() {
            if (Convert.ToDouble(txt_devolucion.Text) == 0.0)
            {

                string vtat = txtVentaOriginal.Text;
                string vtat2 = vtat.Replace(",", "");

                double vtaOriginal = Convert.ToInt32(vtat2) - Convert.ToDouble(TXT_TOTAL_DESCUENTO.Text);
                txtt_importeTotal.Text = Convert.ToString(vtaOriginal);
            }
            else {
                string ventaTempo = txt_total.Text;
                double vtaFinal = Convert.ToDouble(ventaTempo) - Convert.ToDouble(TXT_TOTAL_DESCUENTO.Text);
                txtt_importeTotal.Text = Convert.ToString(vtaFinal);
            }
        }
        public void obtenerTotalFinal() {
            

            double devol = Convert.ToDouble(txt_devolucion.Text);
            if (devol == 0.0)
            {
                txt_total.Text = txtVentaOriginal.Text;
            }
            else {
                double total = Convert.ToDouble(txtVentaOriginal.Text);
                txt_total.Text =Convert.ToString(total - devol);
            }
        }
        public void CALCULAR() {

            double tvta = Convert.ToDouble(txt_total.Text);

            if (tvta >= 1000 && tvta <= 1699)
            {
                txt_descuento.Text = "30%";
            }
            else if (tvta >= 1700 && tvta <= 4999)
            {
                txt_descuento.Text = "35%";
            }
            else if (tvta >= 5000)
            {
                txt_descuento.Text = "50%";

            } else if (tvta < 1000) {
                txt_descuento.Text = "0%";

            }

            double total = Convert.ToDouble(txt_total.Text);
            string descuento = txt_descuento.Text;
            string phrase = descuento.Replace("%","");
            string phrase2 = "0."+ phrase;
            double descuentoTotal = total * Convert.ToDouble(phrase2);

            TXT_TOTAL_DESCUENTO.Text = Convert.ToString(descuentoTotal);
            
        }
        public void calculartabla() {
            foreach (DataGridViewRow Row in dgv_data.Rows)
            {

                Row.Cells["DESCUENTO"].Value = txt_descuento.Text;
                string dato = Convert.ToString(Row.Cells["DESCUENTO"].Value);
                string phrase = dato.Replace("%", "");
                string concatenado = "0." + phrase.ToString().Trim();
                double sumatoria = Convert.ToDouble(concatenado) * Convert.ToDouble(Row.Cells["PRECIO_PUBLICO"].Value);
                double datofinal = Convert.ToDouble(Row.Cells["PRECIO_PUBLICO"].Value) - sumatoria;
                Row.Cells["PRECIO_DESCUENTO"].Value = Convert.ToString(datofinal);
                Row.Cells["IMPORTE"].Value = Convert.ToString(Convert.ToDouble(Row.Cells["PRECIO_DESCUENTO"].Value) * Convert.ToInt32(Row.Cells["CANTIDAD"].Value));

            }
        }

        public void calculartablainicio() {

            double devo = 0.0;
            foreach (DataGridViewRow Row in dgv_data.Rows)
            {

                devo = devo + Double.Parse(Row.Cells["DIFERENCIA"].Value.ToString());

            }
            txt_devolucion.Text = Convert.ToString(devo);
        }
        private void dgv_data_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void BTN_SAVE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
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
                if (TXT_PEDIDO.Text == null || TXT_PEDIDO.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO EL PEDIDO!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (TXT_ADDRESS_CLIENT.Text == null || TXT_ADDRESS_CLIENT.Text == "")
                {
                    XtraMessageBox.Show("¡NO PUEDE DEJAR VACIO LA DIRECCION DE CLIENTE!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string resultado = mtd.VALIDAR_COBRANZA(Convert.ToString(TXT_PEDIDO.Text));

                if (resultado == "1")
                {
                    XtraMessageBox.Show("YA FUE REALIZADA LA COBRANZA DE LA NOTA " + TXT_PEDIDO.Text + " ", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BTN_LIMPIAR_ItemClick(null, null);
                    CLEAR_FIELDS();
                    return;
                }
                else
                {

                    DateTime time = DateTime.Now;
                    string format = "yyyy-MM-dd HH:mm:ss";
                    
                    INSERTA_ENCABEZADO(time.ToString(format));
                    INSERTAR_DETALLE_COBRANZA(time.ToString(format));
                    FOLIO_REMISION();
                    FOLIO_DEVOLUCION();
                    ReporteCobranza(time.ToString(format));
                    ReporteCobranzaDevolucion(time.ToString(format));

                    XtraMessageBox.Show("SE GUARDO CORRECTAMENTE LA COBRANZA DEL PEDIDO " + TXT_PEDIDO.Text + " !!", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    XtraMessageBox.Show("TOTAL A PAGAR ES: $" + string.Format("{0:0,0}", txtt_importeTotal.Text) + " ", "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BTN_LIMPIAR_ItemClick(null, null);
                    CLEAR_FIELDS();
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void INSERTA_ENCABEZADO(string fecha)
        {
            

            try
            {
                mtd.ConectarBaseDatos();


                mtd.comando = new SqlCommand("SP_SILV_COBRANZA_INSERT", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;

                mtd.comando.Parameters.Add("@FOLIO_PEDIDO", SqlDbType.NVarChar, 200).Value = TXT_PEDIDO.Text;
                mtd.comando.Parameters.Add("@ID_CLIENTE", SqlDbType.Int).Value = Convert.ToInt32(TXT_ID_CLIENT.Text);
                mtd.comando.Parameters.Add("@IMPORTE_NOTA", SqlDbType.NVarChar, 200).Value = txt_importe_nota.Text;
                mtd.comando.Parameters.Add("@IMPORTE_DEVOLUCION", SqlDbType.NVarChar, 200).Value = txt_devolucion.Text;
                mtd.comando.Parameters.Add("@VENTA_ORIGINAL", SqlDbType.NVarChar, 200).Value = txtVentaOriginal.Text;
                mtd.comando.Parameters.Add("@TOTAL", SqlDbType.NVarChar, 200).Value = txt_total.Text;
                mtd.comando.Parameters.Add("@PORCENTAJE_DESCUENTO", SqlDbType.NVarChar, 200).Value = txt_descuento.Text;
                mtd.comando.Parameters.Add("@DESCUENTO", SqlDbType.NVarChar, 200).Value = TXT_TOTAL_DESCUENTO.Text;
                mtd.comando.Parameters.Add("@IMPORTE_TOTAL", SqlDbType.NVarChar, 200).Value = txtt_importeTotal.Text;
                mtd.comando.Parameters.Add("@STATUS", SqlDbType.NVarChar, 200).Value = "R";
                mtd.comando.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = fecha;
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
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }
        public void INSERTAR_DETALLE_COBRANZA(string fecha)
        {
            try
            {
                mtd.ConectarBaseDatos();
                foreach (DataGridViewRow row in dgv_data.Rows)
                {

                    string CODIGOG = Convert.ToString(row.Cells["ID_ARTICULO"].Value);
                    int CANTIDADG = Convert.ToInt32(row.Cells["CANTIDAD"].Value);
                    int CANTIDAD_REGRESADAG = Convert.ToInt32(row.Cells["CANTIDAD_REGRESADA"].Value);
                    string DIFERENCIAG = Convert.ToString(row.Cells["DIFERENCIA"].Value);
                    string DESCRIPCIONG = Convert.ToString(row.Cells["DESCRIPCION"].Value);
                    string DESCUENTOG = Convert.ToString(row.Cells["DESCUENTO"].Value);
                    string PRECIO_PUBLICOG = Convert.ToString(row.Cells["PRECIO_PUBLICO"].Value);
                    string PRECIO_DESCUENTOG = Convert.ToString(row.Cells["PRECIO_DESCUENTO"].Value);
                    string IMPORTEG = Convert.ToString(row.Cells["IMPORTE"].Value);
               

                    mtd.comando = new SqlCommand("SP_SILV_COBRANZA_DETALLE_INSERT", mtd.conexion);
                    mtd.comando.CommandType = CommandType.StoredProcedure;

                    mtd.comando.Parameters.Add("@FOLIO_PEDIDO", SqlDbType.NVarChar, 200).Value = TXT_PEDIDO.Text;
                    mtd.comando.Parameters.Add("@FOLIO_ARTICULO", SqlDbType.NVarChar, 200).Value = CODIGOG;
                    mtd.comando.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = CANTIDADG;
                    mtd.comando.Parameters.Add("@CANTIDAD_REGRESADA", SqlDbType.Int).Value = CANTIDAD_REGRESADAG;
                    mtd.comando.Parameters.Add("@DIFERENCIA", SqlDbType.NVarChar, 200).Value = DIFERENCIAG;
                    mtd.comando.Parameters.Add("@DESCRIPCION_ARTICULO", SqlDbType.NVarChar, 200).Value = DESCRIPCIONG;
                    mtd.comando.Parameters.Add("@PORCENTAJE_DESCUENTO", SqlDbType.NVarChar, 200).Value = DESCUENTOG;
                    mtd.comando.Parameters.Add("@PRECIO_PUBLICO", SqlDbType.NVarChar, 200).Value = PRECIO_PUBLICOG;
                    mtd.comando.Parameters.Add("@PRECIO_DESCUENTO", SqlDbType.NVarChar, 200).Value = PRECIO_DESCUENTOG;
                    mtd.comando.Parameters.Add("@IMPORTE", SqlDbType.NVarChar, 200).Value = IMPORTEG;
                    mtd.comando.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = fecha;

                    mtd.comando.ExecuteNonQuery();
                }



            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }

        private void BTN_LIMPIAR_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dgv_data.DataSource is DataTable)
            {
                ((DataTable)dgv_data.DataSource).Rows.Clear();
                dgv_data.Refresh();
                CLEAR_FIELDS();
            }
        }

        public void CLEAR_FIELDS() {
            TXT_PEDIDO.ResetText();
            TXT_NAME_CLIENT.ResetText();
            TXT_ADDRESS_CLIENT.ResetText();
            TXT_ID_CLIENT.ResetText();
            TXT_CURP.ResetText();
            txt_importe_nota.ResetText();
            txt_devolucion.Text = "0.0";
            txtVentaOriginal.ResetText();
            txt_total.ResetText();
            txt_descuento.ResetText();
            TXT_TOTAL_DESCUENTO.ResetText();
            txtt_importeTotal.ResetText();
            string fecha = DateTime.Today.ToString("dd/MM/yyyy");
            TXT_FECHA_ACTUAL.Text = fecha;
        }

        public void ReporteCobranza(string fecha) {
            try
            {



                DataSet Ds_Cobranza_Remision = new DataSet();
                mtd.ConectarBaseDatos();

                mtd.comando = new SqlCommand("SP_OBTENER_DETALLE_COBRANZA", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = TXT_PEDIDO.Text;
                mtd.comando.ExecuteNonQuery();

                SqlDataAdapter adt = new SqlDataAdapter(mtd.comando);
                adt.Fill(Ds_Cobranza_Remision, "DsCobranzaRemision");

                ReportDocument rpt = new ReportDocument();
                PrinterSettings ps = new PrinterSettings();
                ps.Copies = 1;
                PageSettings pg = new PageSettings();
                pg.PrinterSettings = ps;
                rpt.Load(Application.StartupPath + "\\Admininistrador\\ReporteCobranzaRemision.rpt");

                rpt.SetDataSource(Ds_Cobranza_Remision);

                rpt.SetParameterValue("FOLIO_REMISION", folioRemision);
                rpt.SetParameterValue("NOMBRE_CLIENTE", TXT_NAME_CLIENT.Text);
                rpt.SetParameterValue("FECHA", fecha);
                rpt.SetParameterValue("DIRECCION", TXT_ADDRESS_CLIENT.Text);
                rpt.SetParameterValue("CURP", TXT_CURP.Text);
                rpt.SetParameterValue("EMPRESA", nombreSucursal);
                rpt.SetParameterValue("SUCURSAL", direccionSucursal);
                rpt.SetParameterValue("RFC_SUCURSAL", rfcSucursal);
                rpt.SetParameterValue("USUARIO", nombreUser);
                rpt.SetParameterValue("SUBTOTAL", txt_total.Text);
                rpt.SetParameterValue("DESCUENTO", TXT_TOTAL_DESCUENTO.Text);
                rpt.SetParameterValue("TOTAL", txtt_importeTotal.Text);
                rpt.PrintToPrinter(ps, pg, false);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                mtd.DesconectarBaseDatos();
            }
        }

        public void ReporteCobranzaDevolucion(string fecha)
        {
            try
            {



                DataSet Ds_Cobranza_Devolucion = new DataSet();
                mtd.ConectarBaseDatos();

                mtd.comando = new SqlCommand("SP_OBTENER_DEVOLUCION_COBRANZA", mtd.conexion);
                mtd.comando.CommandType = CommandType.StoredProcedure;
                mtd.comando.Parameters.Add("@FOLIO_PEDIDO", SqlDbType.NVarChar, 200).Value = TXT_PEDIDO.Text;
                mtd.comando.ExecuteNonQuery();

                SqlDataAdapter adt = new SqlDataAdapter(mtd.comando);
                adt.Fill(Ds_Cobranza_Devolucion, "DsCobranzaDevolucion");

                ReportDocument rpt = new ReportDocument();
                PrinterSettings ps = new PrinterSettings();
                ps.Copies = 1;
                PageSettings pg = new PageSettings();
                pg.PrinterSettings = ps;
                rpt.Load(Application.StartupPath + "\\Admininistrador\\ReporteCobranzaDevolucion.rpt");

                rpt.SetDataSource(Ds_Cobranza_Devolucion);

                rpt.SetParameterValue("FOLIO_DEVOLUCION", folioDevo);
                rpt.SetParameterValue("NOMBRE_CLIENTE", TXT_NAME_CLIENT.Text);
                rpt.SetParameterValue("FECHA", fecha);
                rpt.SetParameterValue("DIRECCION_CLIENTE", TXT_ADDRESS_CLIENT.Text);
                rpt.SetParameterValue("CURP", TXT_CURP.Text);
                rpt.SetParameterValue("EMPRESA", nombreSucursal);
                rpt.SetParameterValue("SUCURSAL", direccionSucursal);
                rpt.SetParameterValue("RFC_SUCURSAL", rfcSucursal);
                rpt.SetParameterValue("USUARIO", nombreUser);
                rpt.SetParameterValue("NOTA_ORIGINAL", txt_importe_nota.Text);
                rpt.SetParameterValue("DEVOLUCION", txt_devolucion.Text);
                rpt.PrintToPrinter(ps, pg, false);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SISTEMA..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }

        public void FOLIO_REMISION() {
            folioRemision = mtd.GeneradorVenta(usuario,"2");
        }
        public void FOLIO_DEVOLUCION()
        {
            folioDevo = mtd.GeneradorVenta(usuario, "3");
        }
        public void DATOS_COMPLEMENTA()
        {
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
            finally
            {
                mtd.DesconectarBaseDatos();
            }
        }
    }
}