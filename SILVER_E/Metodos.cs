using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace SILVER_E
{
    public class Metodos
    {

#region "VARIABLES"
        public SqlConnection conexion=new SqlConnection(ConfigurationManager.ConnectionStrings["SILVER_ONE_ERP.Settings.SILVER_ERPConnectionString"].ConnectionString.ToString());
        public SqlCommand comando;
        public SqlDataAdapter adaptador;
        public DataTable datatables;
        public SqlDataReader lector;
        public int Rows;
        public DataSet DataS;
        public string Username = "gadiel";
        public string Password = "1992";
#endregion

        #region Basedatos
        public void ConectarBaseDatos()
        {
            if (conexion.State == ConnectionState.Closed)
            {

                conexion.Open();
               
            }
        }

        public void DesconectarBaseDatos()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
        #endregion

        #region MetodosUsuario
        public Boolean UsuarioRegistrado(string nombre_usuario)
        {
            Boolean resultado = false;
            try
            {
                ConectarBaseDatos();
                comando = new SqlCommand("Select * from SILV_USERS where US_USERNAME='" + nombre_usuario + "' and US_ACTIVE_INACTIVE=1", conexion);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    resultado = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"ERROR");
                
            }
            finally
            {
                DesconectarBaseDatos();
            }
            return resultado;
        }
        //VERIFICAR SI EXISTE LA INSTANCIA EN LA BD LOCAL
        public Boolean VerificaInstancia() {

            Boolean resultado = false;
            try
            {
                ConectarBaseDatos();
                comando = new SqlCommand("Select * from SILV_COMPANY", conexion);
                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    resultado = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR");
            }
            finally {
                DesconectarBaseDatos();
            }
            return resultado;
        }
        //
        public String ExisteContrasena(string nombre_usuario)
        {
            string resultado = "";
            try
            {
                ConectarBaseDatos();
                comando = new SqlCommand("Select US_PASSWORD from SILV_USERS where US_USERNAME='" + nombre_usuario + "' and US_ACTIVE_INACTIVE=1", conexion);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    resultado = Convert.ToString(lector["US_PASSWORD"]);
                }
                lector.Close();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message,"ERROR");
            }
            finally
            {
                DesconectarBaseDatos();
            }
            return resultado;
        }
        //
        public int ConsultaTipoUsuario(string nombre_usuario)
        {
            int resultado = 0;
            try
            {
                
                ConectarBaseDatos();
                comando = new SqlCommand("Select ID_USER_TYPE from SILV_USERS where US_USERNAME='" + nombre_usuario + "' and US_ACTIVE_INACTIVE=1", conexion);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    resultado = Convert.ToInt32(lector["ID_USER_TYPE"]);
                }
                lector.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"ERROR");
            }
            finally
            {
                DesconectarBaseDatos();
            }
            return resultado;
            
        }
        public int InsertarInstanciaLocal(DataSet ds) {
            int resultado = 0;

            ConectarBaseDatos();
            if (ds.Tables.Count >0) {
                if (ds.Tables[0].Rows.Count > 0) {
                    for (int i=0; i<=ds.Tables[0].Rows.Count-1;i++) {

                        comando = new SqlCommand("insert into DBO.SILV_COMPANY(COM_NAME_COMPANY,COM_ADDRESS,COM_RFC,COM_LOGO,COM_OBSERVATIONS,COM_NUMBER_COMPANY, " +
                            "COM_SERVER, COM_DB, " +
                            "COM_USERNAME, " +
                            "COM_PASSWORD, " +
                            "COM_IS_SERVER, " +
                            "COM_IS_SERVER_SUC, " +
                            "COM_IS_LOCAL, " +
                            "COM_ACTIVE_INACTIVE, " +
                            "COM_USER_CREATOR, " +
                            "COM_USER_UPDATE, " +
                            "COM_DATE_UPDATE, " +
                            "COM_REGISTRATION_DATE) VALUES('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "',"+
                            "'"+ds.Tables[0].Rows[i][2].ToString()+"',NULL,'"+ds.Tables[0].Rows[i][4].ToString()+"',"+ds.Tables[0].Rows[i][5].ToString()+", "+
                            "'" + ds.Tables[0].Rows[i][6].ToString() + "','" + ds.Tables[0].Rows[i][7].ToString() + "','" + ds.Tables[0].Rows[i][8].ToString() + "', "+
                            "'" + ds.Tables[0].Rows[i][9].ToString() + "','" + ds.Tables[0].Rows[i][10].ToString() + "','" + ds.Tables[0].Rows[i][11].ToString() + "', "+
                            "'" + ds.Tables[0].Rows[i][12].ToString() + "','" + ds.Tables[0].Rows[i][13].ToString() + "','" + ds.Tables[0].Rows[i][14].ToString() + "', "+
                            "'" + ds.Tables[0].Rows[i][15].ToString() + "',getdate(),getdate() "+
                            ")", conexion);

                        try {
                            comando.ExecuteNonQuery();
                        } catch {
                            DesconectarBaseDatos();
                            resultado = 2;
                            return resultado;
                        }
                    }
                }
            }
            resultado = 3;
            DesconectarBaseDatos();
            return resultado;

        }

        public string ObtenerMac() {
            string mac_src = "";
            string macAddress = "";

            foreach (System.Net.NetworkInformation.NetworkInterface nic in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    mac_src += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        macAddress = macAddress.Insert(macAddress.Length, mac_src.Substring(i, 2)) + "-";
                    }
                }
            }
            return macAddress;
        }

        public DataSet GetDatosEmpresa() {
            ConectarBaseDatos();
            try
            {
                DataSet dEmpresa = new DataSet();
                comando = new SqlCommand("select TOP 1 COM_NAME_COMPANY + ' - '+CONVERT(VARCHAR,ID_COMPANY) FROM SILV_COMPANY WHERE ID_COMPANY <> 1", conexion);
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dEmpresa);
                DesconectarBaseDatos();
                return dEmpresa;
            }
            catch {
                DesconectarBaseDatos();
                return null;
            }
        }

        public DataSet GetClientes()
        {
            ConectarBaseDatos();
            try {
                DataSet dCliente = new DataSet();
                comando = new SqlCommand("SP_LIST_CLIENTES_ID_NOMBRE", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
                //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
                Message.Direction = ParameterDirection.Output;
                //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
                comando.Parameters.Add(Message);
                //LE ASIGNAMOS A LA VARIABLE    Public Rows As Integer LA EJECUCION DEL COMANDO ACTUAL  Command = New SqlCommand("SP_SILV_COUNTRIES_INSERT", connection)
                Rows = comando.ExecuteNonQuery();
                //SI LA EJECUCION DEL COMANDO RETORNA UN VALOR DE LOS POSIBLES DE NUESTRO PROCEDIMIENTO SP_SILV_COUNTRIES_INSERT SE MUESTRA UN VALOR EN UN MENSAJE DE TIPO  XtraMessageBox DE LA LIBRERIA DEXEXPRESS
                if (Rows > 0)
                {
                    XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                }
                else
                {
                    XtraMessageBox.Show(Convert.ToString(Message.Value), "SISTEMA", MessageBoxButtons.OK);
                }
                adaptador = new SqlDataAdapter(comando);
                adaptador.Fill(dCliente);

                DesconectarBaseDatos();
                return dCliente;
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DesconectarBaseDatos();
                return null;
            }
        }

        public void llenarDetalleFolio(DataGridView grid, string folio) {
            comando = new SqlCommand("SP_OBTENER_DETALLE_PEDIDO", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@FOLIO_VENTA", SqlDbType.NVarChar, 200).Value = folio;
            SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
            Message.Direction = ParameterDirection.Output;
            comando.Parameters.Add(Message);

            adaptador = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);

            grid.DataSource = dt;
           
        }

        #endregion

        public string Generadores(string Tabla) {
            string result = "";
           
            int ult = 0;

            //SIGUIENTE LINEA SE REEMPLAZA POR USO DE UN PARAMETRO ALMACENADO
            SqlCommand cmd = new SqlCommand("SELECT GEN_ULTIMO FROM SILV_GENERADOR WHERE COM_PARAMETRO='"+Tabla+"'", conexion);
            try
            {
                ConectarBaseDatos();
                SqlDataReader dr1;
                dr1 = cmd.ExecuteReader();
                while (dr1.Read()) { 
                    ult = Convert.ToInt32(dr1["GEN_ULTIMO"]) + 1;
                }
                DesconectarBaseDatos();

                int CEROS = 0; 
                
                CEROS = (5) - Convert.ToInt32(Convert.ToString(ult).Insert(0," ").Length);
                switch (CEROS)
                {
                    case 3:                       
                        result =Tabla.Substring(0, 3) + "000" + Convert.ToString(Convert.ToString(ult)).Trim();
                        break;
                    case 2:
                        result = Tabla.Substring(0, 3) + "00" + Convert.ToString(Convert.ToString(ult)).Trim();
                        break;
                    case 1: 
                        result = Tabla.Substring(0, 3) + "0" + Convert.ToString(Convert.ToString(ult)).Trim();
                        break;
                    case 0: 
                        result = Tabla.Substring(0, 3) + "" + Convert.ToString(Convert.ToString(ult)).Trim();
                        break;
                }
                return result;     
            }
            
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
        public string GeneradorVenta(string idUser, string tipoVenta) {
            string result = "";

            //SIGUIENTE LINEA SE REEMPLAZA POR USO DE UN PARAMETRO ALMACENADO
            comando = new SqlCommand("OBTENER_FOLIO_VTA", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@NOMBRE_USER", SqlDbType.NVarChar, 200).Value = idUser;
            comando.Parameters.Add("@TIPO_VENTA", SqlDbType.NVarChar, 200).Value = tipoVenta;

            SqlParameter Message = new SqlParameter("@MENSAJE", SqlDbType.NVarChar, 200);
            //INDICAMOS QUE SE TRATA DE UN PARAMETRO DE TIPO OUTPUT
            Message.Direction = ParameterDirection.Output;
            //A NUESTRO COMANDO A EJCUTAR LE AÑADIMOS EL PARAMETRO NECESARIO PARA SU EJECUCION
            comando.Parameters.Add(Message);
            try
            {
                ConectarBaseDatos();
                SqlDataReader dr1;
                dr1 = comando.ExecuteReader();
                while (dr1.Read())
                {
                    result = Convert.ToString(dr1["FOLIO"]);
                }
                DesconectarBaseDatos();

                return result;
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }

        public string VALIDAR_COBRANZA(string pedido)
        {
            string result = "";

            //SIGUIENTE LINEA SE REEMPLAZA POR USO DE UN PARAMETRO ALMACENADO
            comando = new SqlCommand("VALIDA_COBRANZA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@PEDIDO", SqlDbType.NVarChar, 200).Value = pedido;
            try
            {
                ConectarBaseDatos();
                SqlDataReader dr1;
                dr1 = comando.ExecuteReader();
                while (dr1.Read())
                {
                    result = Convert.ToString(dr1["RESULT"]);
                }
                DesconectarBaseDatos();

                return result;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
    }
}
