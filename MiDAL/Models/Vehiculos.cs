using System;
using System.Collections.Generic;

namespace MiDAL.Models
{
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            Ppto = new HashSet<Ppto>();
            Repara = new HashSet<Repara>();
            Ventas = new HashSet<Ventas>();
        }

        public int IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Bastidor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public float? Precio { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdConce { get; set; }
        public string Tipo { get; set; }
        public int? Ano { get; set; }
        public int? Kilometros { get; set; }
        public string Combustible { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual Concesionario IdConceNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Ppto> Ppto { get; set; }
        public virtual ICollection<Repara> Repara { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
