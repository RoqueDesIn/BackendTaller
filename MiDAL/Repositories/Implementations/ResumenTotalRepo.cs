using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiCore.DTO;
using MiDAL.Models;
using MiDAL.Repositories.Contracts;

namespace MiDAL.Repositories.Implementations
{
    public class ResumenTotalRepo : IresumTotalRepo
    {

        public proyectoContext _context { get; set; }
        public ResumenTotalRepo(proyectoContext context)
        {
            _context = context;
        }
        public IEnumerable<Usuarios> Getusers()
        {
            var usuarios = _context.Usuarios.ToList();
            return usuarios;
            //throw new NotImplementedException();
        }

        public IEnumerable<Ventas> Getventas()
        {
            var ventas = _context.Ventas.ToList();
            return ventas;
            //throw new NotImplementedException();
        }
    }
}
