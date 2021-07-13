using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Entity
    {
        public int Id { get; set; }
        public EstadoGeneral Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public enum EstadoGeneral { 
        Inactivo = 0,
        Activo = 1

    }
}
