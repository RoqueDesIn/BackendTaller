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

            var ventas = _context.Ventas.ToList();
            int total = 0;
            int valor = 0;
            foreach (var v in ventas)
            {
                total++;
                valor = (int)(valor + v.Precio);
            }


            var result=new List<ResumTotal>();
            ResumTotal r = new ResumTotal();
            r.cant = total;
            r.total = valor;
            result.Add(r);
            return result;
            //throw new NotImplementedException();
        }
    }
}
