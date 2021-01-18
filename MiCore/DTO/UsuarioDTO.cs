using System;
using System.Collections.Generic;
using System.Text;

namespace MiCore.DTO
{
    public class UsuarioDTO
    {
        public string Dni { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Rango { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Foto { get; set; }
        public int IdUser { get; set; }

    }
}
