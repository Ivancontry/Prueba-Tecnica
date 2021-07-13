using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente: Entity
    {       
        public string Identificacion { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }  
        public double Salario { get; private set; }

        public Cliente()
        {

        }
        public Cliente(string identificacion, string nombres, string apellidos, string telefono, string direccion, double salario)
        {
            Identificacion = identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Salario = salario;
            FechaCreacion = DateTime.Now;
            Estado = EstadoGeneral.Activo;
        }

        public void Editar(string identificacion, string nombres, string apellidos, string telefono, string direccion, double salario)
        {
            Identificacion = identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Salario = salario;
        }
    }
}
