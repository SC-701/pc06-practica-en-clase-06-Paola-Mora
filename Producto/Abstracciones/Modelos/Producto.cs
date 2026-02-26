using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {

        [Required(ErrorMessage = "La propiedad nombre es requerida")]
        [RegularExpression(@"/^\p{Lu}\p{L}*\s((\p{Lu}\p{L}*)+\s)*\p{Lu}\p{L}*$/gu", ErrorMessage = "El nombre debe tener dos o más palabras iniciadas en mayúscula")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad descripción es requerida")]
        [StringLength(300, ErrorMessage = "La propiedad descripción debe ser mayor a 100 caracteres y menor de 300", MinimumLength = 100)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La propiedad precio es requerida")]
        [RegularExpression(@"/(\d)(?=(\d{3})+)/g", ErrorMessage = "Formato inválido. Ejemplo: 1.234.567")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad stock es requerida")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "La propiedad código de barras es requerida")]
        [RegularExpression(@"^[A-Z]{3}-\d{3}$", ErrorMessage = "Ingresa la placa con 3 letras mayúsculas, un guion y 3 números.Ejemplo: ABC-123")]
        public string CodigoBarras { get; set; }
        public decimal PrecioCRC { get; set; }
        public decimal PrecioUSD { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string SubCategoria { get; set; }
        public string Categoria { get; set; }
    }

    public class ProductoPrecio : ProductoRequest
    {
        public decimal Precio { get; set; }
    }



}
