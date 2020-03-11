using Microsoft.AspNetCore.Mvc;
using SenaTur.Senai.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaTur.Senai.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuariosRepository banco = new UsuariosRepository();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(banco.Listar());
        }
    }
}
