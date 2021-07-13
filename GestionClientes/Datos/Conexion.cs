using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private const string servidor = "localhost";
        private const string puerto = "3306";
        private const string usuario = "root";
        private const string password = "admin";
        private const string database = "clientes_db";

        public MySqlConnection Connection { get; set; }
        public MySqlCommand Cmd { get; set; }
        public string ConnectionString { get; set; } = string.Format("server={0};port={1};user id={2}; password={3}; " +
                    "database={4}; pooling=false;SslMode=none;" +
                    "Allow Zero Datetime=False;Convert Zero Datetime=True",
                    servidor, puerto, usuario, password, database);
        public bool Conectar()
        {
            try
            {
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DesConectar()
        {
            try
            {
                Connection = new MySqlConnection(ConnectionString);
                Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public DataTable LlenarDataTable(MySqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
            mySqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable CargarRegistros(string procedimiento)
        {
            try
            {
                if (Conectar())
                {
                    Cmd = new MySqlCommand(procedimiento, Connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    if (Cmd.ExecuteNonQuery() >= 0)
                    {
                        return LlenarDataTable(Cmd);
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                DesConectar();
            }
        }

    }
}
