using System;
using System.Collections.Generic;
using System.Text;
using MiBL.Contracts;
using MiCore.DTO;
using MiDAL.Models;
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

            var ventas = _resum.Getventas();
            int total = 0;
            int valor = 0;
            foreach (var v in ventas)
            {
                total++;
                valor = (int)(valor + v.Precio);
            }


            var result = new List<ResumTotal>();
            ResumTotal r = new ResumTotal();
            r.cant = total;
            r.total = valor;
            result.Add(r);
            return result;
        }

        public IEnumerable<ResumUser> GetRU()
        {
            var ventas = _resum.Getventas();
            var usuarios = _resum.Getusers();
            var result = new List<ResumUser>();
            List<int> numeros = new List<int>();
            foreach (var v in ventas)
            {
                if (Comprobarrepe(numeros, (int)v.IdEmple))
                {
                    foreach (var r in result)
                    {
                        if (r.id == (int)v.IdEmple)
                        {
                            r.cantidad++;
                            r.valor = r.valor + (int)v.Precio;
                        }
                    }
                }
                else
                {
                    numeros.Add((int)v.IdEmple);
                    var resum = new ResumUser();
                    resum.id = (int)v.IdEmple;
                    resum.cantidad = 1;
                    resum.valor = (int)v.Precio;
                    result.Add(resum);
                }
            }

            foreach (var r in result)
            {
                foreach (var u in usuarios)
                {
                    if (r.id == u.IdUser)
                    {
                        r.nombre = u.Nick;
                    }
                }
            }


            return result;
        }

        bool Comprobarrepe(List<int> numeros, int numero)
        {
            bool esta = false;
            foreach (var n in numeros)
            {
                if (n == numero && esta == false)
                {
                    esta = true;
                }
            }
            return esta;
        }
    }

   
}
