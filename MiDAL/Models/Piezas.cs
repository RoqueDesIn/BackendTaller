using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Piezas
    {
        public Piezas()
        {
            Piezasrep = new HashSet<Piezasrep>();
        }

        public int IdPieza { get; set; }
        public string Descripcion { get; set; }
        public float? Precio { get; set; }
        public DateTime? FechaAlta { get; set; }

        public virtual ICollection<Piezasrep> Piezasrep { get; set; }
    }
}
