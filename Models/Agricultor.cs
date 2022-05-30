using System;
using System.Collections.Generic;

#nullable disable

namespace feria.Models
{
    public partial class Agricultor
    {
        public Agricultor()
        {
            Puestos = new HashSet<Puesto>();
        }

        public int IdAgricultor { get; set; }
        public string Nombre { get; set; }
        public string Apel1 { get; set; }
        public string Apel2 { get; set; }

        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}
