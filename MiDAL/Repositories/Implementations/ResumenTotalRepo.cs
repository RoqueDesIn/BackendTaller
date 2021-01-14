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
        public IEnumerable<ResumTotal> Get()
        {
            int cantidad = _context.Ventas.Count();
            //int valor = _context.Ventas.Sum(Venta);
            throw new NotImplementedException();
        }
    }
}
