using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPPRO.Persistence.Contexto;
using ERPPRO.Domain;
using Microsoft.AspNetCore.Mvc;
using ERPPRO.Application.Contracts;
using Microsoft.AspNetCore.Http;
using ERPPRO.Application;

namespace ERPPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoApplication _eventoApplication;

        public EventoController(IEventoApplication eventoApplication)
        {
            _eventoApplication = eventoApplication;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos  = await _eventoApplication.GetAllEventosAsync(true);
                if (eventos == null) return NotFound("Nenhum registro encontrado!");
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar todos os eventos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetId(int id)
        {
            try
            {
                var evento = await _eventoApplication.GetIdEventoAsync(id, true);
                if (evento == null) return NotFound("Nenhum registro encontrado!");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar o evento: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _eventoApplication.AddEventos(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento!");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar o evento: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoApplication.UpdateEventos(id, model);
                if (evento == null) return BadRequest("Erro ao tentar editar evento!");
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o evento: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoApplication.DeleteEvento(id)
                    ? Ok("Deletado!")
                    : BadRequest("evento não deletado!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar o evento: {ex.Message}");
            }
        }
    }
}