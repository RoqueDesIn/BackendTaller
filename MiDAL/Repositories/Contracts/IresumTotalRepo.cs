using System;
using System.Collections.Generic;
using System.Text;
using MiCore.DTO;


namespace MiDAL.Repositories.Contracts
{
    public interface IresumTotalRepo
    {
        IEnumerable<ResumTotal> Get();
    }
}
