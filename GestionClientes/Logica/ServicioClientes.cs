using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioClientes
    {
        RepositorioClientes Repositorio = new RepositorioClientes();
        public string Registrar(Cliente cliente)
        {
            return Repositorio.Registrar(cliente);
        }
        public string Actualizar(Cliente cliente)
        {
            return Repositorio.Actualizar(cliente);
        }        

        public List<Cliente> VerClientes()
        {
            return Repositorio.ConsultarClientes();
        }

        public Cliente BuscarPorIdentificacion(string identificacion)
        {
            return Repositorio.BuscarPorIdentificacion(identificacion);
        }

        public List<Cliente> ConsultarClientes()
        {
            return Repositorio.ConsultarClientes();
        }

        public string CambiarEstado(int id, EstadoGeneral estado)
        {
             return Repositorio.CambiarEstado(id,estado);
        }
    }
}
