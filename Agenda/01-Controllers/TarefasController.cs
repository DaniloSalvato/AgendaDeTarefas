﻿using Agenda._02_Services.Interface;
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

        [HttpGet("SearchTarefas")]
        [ProducesResponseType(typeof(AgendaModel), 200)]
        [ProducesResponseType(typeof(object), 400)]
        public async Task<IActionResult> SearchScore()
        {
            var response = await _tarefaService.GetAllTarefas();
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
