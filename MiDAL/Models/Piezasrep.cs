using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Piezasrep
    {
        public int IdRep { get; set; }
        public int? IdPieza { get; set; }
        public float? Precio { get; set; }

        public virtual Piezas IdPiezaNavigation { get; set; }
        public virtual Repara IdRepNavigation { get; set; }
    }
}
