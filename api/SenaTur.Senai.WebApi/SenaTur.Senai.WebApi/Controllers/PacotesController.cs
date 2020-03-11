using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaTur.Senai.WebApi.Domains;
using SenaTur.Senai.WebApi.Repositories;

namespace SenaTur.Senai.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        PacotesRepository banco = new PacotesRepository();

        [HttpGet("{id}")]
        public IActionResult BuscarPeloId(int id)
        {
            try
            {
                return Ok(banco.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                var motivo = $"A sua busca não foi bem sucedida, {ex.Message}";
                return BadRequest(motivo);
            }
        }


        [HttpPut("{id}")]

        public IActionResult ModificarPacote(int id, Pacotes pacote)
        {
            try
            {
                var modificar = banco.Atualizar(id, pacote);
                return Ok(modificar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}