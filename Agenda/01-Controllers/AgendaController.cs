using Agenda._02_Services.Interface;
using Agenda._04_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Agenda._01_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet("ListarAgendas")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> ListarAgendas()
        {
            try
            {
                var response = await _agendaService.GetAllAgendas();
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("ListarAgenda")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> ListarAgenda(SingleAgendaModel agendaId)
        {
            try
            {
                var response = await _agendaService.GetAgenda(agendaId.Id);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("InsertAgendas")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> NovaAgenda(NovaAgendaModel model)
        {
            try
            {
                var response = await _agendaService.NovaAgenda(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("AtualizaAgendas")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> AtualizaAgenda(AtualizarAgendaModel model)
        {
            try
            {
                var response = await _agendaService.AtualizarAgenda(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut("DesativaAgendas")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> DesativaAgendas(DesabilitaAgendaModel model)
        {
            try
            {
                var response = await _agendaService.DesabilitaAgendas(model);
                return StatusCode(StatusCodes.Status200OK, response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
