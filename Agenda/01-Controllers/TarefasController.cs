using Agenda._02_Services.Interface;
using Agenda._04_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agenda._01_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("ListarTarefas")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> ListarTarefas(int agendaId)
        {
            try
            {
                var response = await _tarefaService.GetAllTarefas(agendaId);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost("NovaTarefas")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> NovaTarefa(NovaTarefaModel model)
        {
            try
            {
                var response = await _tarefaService.NovaTarefa(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut("AtualizarTarefa")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> AtualizarTarefa(AtualizarTarefaModel model)
        {
            try
            {
                var response = await _tarefaService.AtualizarTarefa(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
