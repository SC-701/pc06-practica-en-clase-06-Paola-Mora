using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Servicios
{
    public class Indicador
    {
        public string CodigoIndicador { get; set; }
        public string NombreIndicador { get; set; }
        public List<Serie> Series { get; set; }
    }
}
