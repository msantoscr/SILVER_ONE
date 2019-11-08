using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraEditors;


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

        #endregion
    }
}
