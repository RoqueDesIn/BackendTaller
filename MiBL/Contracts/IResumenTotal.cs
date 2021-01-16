using System;
using System.Collections.Generic;
using System.Text;
using MiCore.DTO;


namespace MiBL.Contracts
{
   public interface IResumenTotal
    {
        IEnumerable<ResumTotal> Get();
        IEnumerable<ResumUser> GetRU();
    }
}
