using System;
using System.Collections.Generic;

#nullable disable

namespace feria.Models
{
    public partial class Puesto
    {
        public int IdPuesto { get; set; }
        public int? IdAgricultor { get; set; }
        public int? IdProducto1 { get; set; }
        public int? IdProducto2 { get; set; }
        public int? IdProducto3 { get; set; }
        public int? IdProducto4 { get; set; }
        public int? IdProducto5 { get; set; }
        public bool? Disponibilidad { get; set; }

        public virtual Agricultor IdAgricultorNavigation { get; set; }
        public virtual Producto IdProducto1Navigation { get; set; }
        public virtual Producto IdProducto2Navigation { get; set; }
        public virtual Producto IdProducto3Navigation { get; set; }
        public virtual Producto IdProducto4Navigation { get; set; }
        public virtual Producto IdProducto5Navigation { get; set; }
    }
}
