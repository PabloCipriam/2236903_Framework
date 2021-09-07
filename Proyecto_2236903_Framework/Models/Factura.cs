using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_2236903_Framework.Models
{
    public class Factura
    {
        [Required]
        [StringLength(10)]
        public String nombreCliente { get; set; }

        [Required]
        public String documentoCliente { get; set; }

        [Required]
        [StringLength(10)]
        public String nombreProducto { get; set; }

        [Required]
        public int precioProducto { get; set; }

        [Required]
        public int cantidadProducto { get; set; }
    }
}