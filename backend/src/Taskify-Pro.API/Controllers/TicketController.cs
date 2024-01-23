using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskify_Pro.API.Models;

namespace Taskify_Pro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        public IEnumerable<Ticket> Tickets = new List<Ticket>()
            {
                new Ticket(1),
                new Ticket(2),
                new Ticket(3)
            };

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return Tickets;
        }
        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            return Tickets.FirstOrDefault(tic => tic.Id.Equals(id));
        }
        [HttpPost]
        public IEnumerable<Ticket> Post(Ticket ticket)
        {
            return Tickets.Append<Ticket>(ticket);
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Meu primeiro método Get com o paramêtro {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Meu primeiro método Delete com o paramêtro {id}";
        }
    }
}