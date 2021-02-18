using MiBL.Contracts;
using MiCore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResumController : ControllerBase
    {
        public IResumenTotal _resumt { get; set; }
        public IResumenTotal _resumg { get; set; }
        public ResumController(IResumenTotal resumt) {
            _resumt = resumt;

        }

        /*
         * Devuelve json con el total ventas 
         * y cantidad de articulos vendidos
         */
        [HttpGet]
        public ActionResult<IEnumerable<ResumTotal>> Get()
        {
            return Ok(_resumt.Get());
        }

        /*
         * devuelve json con los registros por usuario:  
         * id, nombre, cantidad y valor
         */
        [HttpGet]
        [Route("UserResum")]
        public ActionResult<IEnumerable<ResumUser>> GetUR() { 
            return Ok(_resumt.GetRU());
        }

        /* 
         * este no funciona era para sacar los datos del gráfico 
         * que no llegué a terminar en la práctica anterior
         */
        [Route("UserResumGraf")]
        public ActionResult<string> GetURG()
        {
            return Ok(_resumg.GetURGbl());
        }

    }
}
