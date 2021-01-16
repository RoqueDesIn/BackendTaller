using System;
using System.Collections.Generic;
using System.Text;
using MiCore.DTO;
using MiDAL.Models;

namespace MiDAL.Repositories.Contracts
{
    public interface IresumTotalRepo
    {

        IEnumerable<Usuarios> Getusers();
        IEnumerable<Ventas> Getventas();
    }
}
