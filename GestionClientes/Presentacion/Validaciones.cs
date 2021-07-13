using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Validaciones
    {
        public static bool ValidarTexto(string texto)
        {
            return string.IsNullOrEmpty(texto);
        }
        public static bool ValidarIdentificacion(string identificacion)
        {
            return identificacion.Length >= 6 && identificacion.Length <= 15;
        }

        public static bool ValidarNombres(string nombres)
        {
            return nombres.Length <= 30;
        }
        public static bool ValidarApellidos(string nombres)
        {
            return nombres.Length <= 30;
        }
        public static bool ValidarTelefono(string telefono)
        {
            return telefono.Length >= 6 && telefono.Length <= 10;
        }
        public static bool ValidarRazonGasto(string razonGasto)
        {
            return razonGasto.Length >= 5 && razonGasto.Length <= 250;
        }
        public static bool ValidarSoloNumeros(string numero)
        {
            return !Regex.IsMatch(numero, @"/^[0-9]$/");
        }
    }
}
