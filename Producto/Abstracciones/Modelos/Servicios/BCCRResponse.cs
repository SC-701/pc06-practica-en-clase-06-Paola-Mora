using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Servicios
{
    public class BCCRResponse
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public List<DatoBCCR> Datos { get; set; }
    }

}
