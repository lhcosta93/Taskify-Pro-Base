using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskify_Pro.Data.Context;
using Taskify_Pro.Domain.Entities;
using Taskify_Pro.Domain.Interfaces.Services;

namespace Taskify_Pro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _TicketService;

        public TicketController(ITicketService ticketService)
        {
            _TicketService = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tickets = await _TicketService.getAllTicketAsync();
                if (tickets == null) return NoContent();
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o ticket.\n\nErro{ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var ticket = await _TicketService.getTicketByIdAsync(id);
                if (ticket == null) return NoContent();
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o ticket com id: {id}.\n\nErro{ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Ticket model)
        {
            try
            {
                var ticketUpdated = await _TicketService.addTicket(model);
                if (ticketUpdated == null) return NoContent();
                return Ok(ticketUpdated);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar o ticket com id: {model.Id}.\n\nErro{ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ticket model)
        {
            try
            {
                if (!model.Id.Equals(id)) return this.StatusCode(StatusCodes.Status409Conflict, "Você está tentando atualizar a atividade errada");

                var ticketUpdated = await _TicketService.updateTicket(model);

                if (ticketUpdated == null) return NoContent();
                return Ok(ticketUpdated);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o ticket com id: {id}.\n\nErro{ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _TicketService.deleteTicket(id)) return Ok(new { message = "Deletado" });
                return BadRequest("Ocorreu um erro não específicado ao tentar deletar o ticket.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar o ticket com id: {id}.\n\nErro{ex.Message}");
            }
        }
    }
}