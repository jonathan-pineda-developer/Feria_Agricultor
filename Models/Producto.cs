using System;
using System.Collections.Generic;

#nullable disable

namespace feria.Models
{
    public partial class Producto
    {
        public Producto()
        {
            PuestoIdProducto1Navigations = new HashSet<Puesto>();
            PuestoIdProducto2Navigations = new HashSet<Puesto>();
            PuestoIdProducto3Navigations = new HashSet<Puesto>();
            PuestoIdProducto4Navigations = new HashSet<Puesto>();
            PuestoIdProducto5Navigations = new HashSet<Puesto>();
        }

        public int IdProducto { get; set; }
        public int? IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int? Unidades { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<Puesto> PuestoIdProducto1Navigations { get; set; }
        public virtual ICollection<Puesto> PuestoIdProducto2Navigations { get; set; }
        public virtual ICollection<Puesto> PuestoIdProducto3Navigations { get; set; }
        public virtual ICollection<Puesto> PuestoIdProducto4Navigations { get; set; }
        public virtual ICollection<Puesto> PuestoIdProducto5Navigations { get; set; }
    }
}
