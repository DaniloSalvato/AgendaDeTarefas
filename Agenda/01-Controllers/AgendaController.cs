using Agenda._02_Services.Interface;
using Agenda._03_Repositories.Interface;
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

        [HttpGet("SearchAgendas")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> SearchAgendas()
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
    }
}
