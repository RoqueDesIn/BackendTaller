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

        public ResumController(IResumenTotal resumt) {
            _resumt = resumt;

        }

        [HttpGet]
        public ActionResult<IEnumerable<ResumTotal>> Get()
        {
            return Ok(_resumt.Get());
        }


        [HttpGet]
        [Route("UserResum")]
        public ActionResult<IEnumerable<ResumUser>> GetUR() { 
            return Ok(_resumt.GetRU());
        }




    }
}
