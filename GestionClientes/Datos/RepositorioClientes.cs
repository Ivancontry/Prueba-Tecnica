using Entidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioClientes : Conexion
    {
        List<Cliente> Clientes = new List<Cliente>();
        private DataTable dataTable = new DataTable();

        public new MySqlCommand Cmd { get; set; }       

        public string Registrar(Cliente cliente)
        {
            try
            {
                if (Conectar())
                {
                    MySqlTransaction transaction = Connection.BeginTransaction();

                    Cmd = new MySqlCommand("RegistrarCliente", Connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Cmd.Parameters.Add(new MySqlParameter("_fechaCreacion", cliente.FechaCreacion));
                    Cmd.Parameters.Add(new MySqlParameter("_identificacion", cliente.Identificacion));
                    Cmd.Parameters.Add(new MySqlParameter("_nombres", cliente.Nombres));
                    Cmd.Parameters.Add(new MySqlParameter("_direccion", cliente.Direccion));
                    Cmd.Parameters.Add(new MySqlParameter("_telefono", cliente.Telefono));
                    Cmd.Parameters.Add(new MySqlParameter("_apellidos", cliente.Telefono));
                    Cmd.Parameters.Add(new MySqlParameter("_salario", cliente.Telefono));
                    Cmd.Parameters.Add(new MySqlParameter("_estado", cliente.Estado));

                    if (Cmd.ExecuteNonQuery() >= 0)
                    {
                        transaction.Commit();
                        return $"Cliente {cliente.Identificacion} {cliente.Nombres.ToUpper()} {cliente.Apellidos.ToUpper()} fue Registrado con Éxito";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error Conectar Base Datos";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                DesConectar();
            }
        }

        public string CambiarEstado(int id, EstadoGeneral estado)
        {
            try
            {
                if (Conectar())
                {
                    MySqlTransaction transaction = Connection.BeginTransaction();

                    Cmd = new MySqlCommand("CambiarEstadoCliente", Connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Cmd.Parameters.Add(new MySqlParameter("_id", id));
                    Cmd.Parameters.Add(new MySqlParameter("_nuevo_estado", estado));

                    if (Cmd.ExecuteNonQuery() >= 0)
                    {
                        transaction.Commit();
                        return "¡Cliente Eliminado con Éxito!";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error Conectar Base Datos";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                DesConectar();
            }
        }

        public string Actualizar(Cliente cliente)
        {
            try
            {
                if (Conectar())
                {
                    MySqlTransaction transaction = Connection.BeginTransaction();

                    Cmd = new MySqlCommand("ActualizarCliente", Connection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    Cmd.Parameters.Add(new MySqlParameter("_id", cliente.Id));
                    Cmd.Parameters.Add(new MySqlParameter("_fechaCreacion", cliente.FechaCreacion));
                    Cmd.Parameters.Add(new MySqlParameter("_identificacion", cliente.Identificacion));
                    Cmd.Parameters.Add(new MySqlParameter("_nombres", cliente.Nombres));
                    Cmd.Parameters.Add(new MySqlParameter("_direccion", cliente.Direccion));
                    Cmd.Parameters.Add(new MySqlParameter("_telefono", cliente.Telefono));
                    Cmd.Parameters.Add(new MySqlParameter("_apellidos", cliente.Apellidos));
                    Cmd.Parameters.Add(new MySqlParameter("_salario", cliente.Telefono));
                    Cmd.Parameters.Add(new MySqlParameter("_estado", cliente.Estado));

                    if (Cmd.ExecuteNonQuery() >= 0)
                    {
                        transaction.Commit();
                        return $"Cliente {cliente.Identificacion} {cliente.Nombres.ToUpper()} {cliente.Apellidos.ToUpper()} fue actualizado con Éxito";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    return "Error Conectar Base Datos";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                DesConectar();
            }
        }

        public List<Cliente> ConsultarClientes()
        {
            dataTable = CargarRegistros("ConsultarClientes");
            if (dataTable == null)
            {
                return Clientes = null;
            }
            else
            {
                Clientes.Clear();
                foreach (DataRow row in dataTable.Rows)
                {
                    Cliente cliente = new Cliente(row["IDENTIFICACION"].ToString(), row["NOMBRE"].ToString(), 
                                                    row["APELLIDOS"].ToString(),row["TELEFONO"].ToString(),
                                                    row["DIRECCION"].ToString(),double.Parse(row["SALARIO"].ToString()));
                    cliente.FechaCreacion = DateTime.Parse(row["FECHACREACION"].ToString());
                    cliente.Id = int.Parse( row["ID"].ToString());
                    if (int.Parse(row["ESTADO"].ToString()) == 0)
                    {
                        cliente.Estado = EstadoGeneral.Inactivo;
                    }
                    else 
                    {
                        cliente.Estado = EstadoGeneral.Activo;
                    }

                   
                    Clientes.Add(cliente);
                }
                return Clientes.FindAll(t=> t.Estado == EstadoGeneral.Activo);
            }
        }
        public Cliente BuscarPorIdentificacion(string identificacion)
        {
            Clientes?.Clear();
            Clientes = ConsultarClientes();
            if (Clientes == null)
            {
                return null;
            }
            else
            {
                return Clientes.FirstOrDefault(t => t.Identificacion == identificacion && t.Estado == EstadoGeneral.Activo);
            }
        }

        
    }
}
