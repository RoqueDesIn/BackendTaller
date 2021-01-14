using System;
using System.Collections.Generic;
using System.Text;
using MiBL.Contracts;
using MiCore.DTO;
using MiDAL.Repositories.Contracts;

namespace MiBL.Implementations
{
    public class ResumenTotal : IResumenTotal
    {

        public IresumTotalRepo _resum { get; set; }
        public ResumenTotal(IresumTotalRepo resum)
        {
            _resum = resum;
        }
        public IEnumerable<ResumTotal> Get()
        {

            var datos = _resum.Get();
            return datos;
        }
    }

        
}
