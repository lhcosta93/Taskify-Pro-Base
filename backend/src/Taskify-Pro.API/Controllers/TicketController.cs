using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskify_Pro.API.Data;
using Taskify_Pro.API.Models;

namespace Taskify_Pro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly DataContext _context;

        public TicketController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _context.Ticket;
        }
        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            return _context.Ticket.FirstOrDefault(tic => tic.Id.Equals(id));
        }
        [HttpPost]
        public Ticket Post(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            if (_context.SaveChanges() > 0) return _context.Ticket.FirstOrDefault(ativ => ativ.Id.Equals(ticket.Id));
            else throw new Exception("Você não conseguiu adicionar uma atividade");
        }
        [HttpPut("{id}")]
        public Ticket Put(int id, Ticket ticket)
        {
            if (!ticket.Id.Equals(id)) throw new Exception("Você está tentando atualizar a atividade errada");
            _context.Update(ticket);

            if (_context.SaveChanges() > 0) return _context.Ticket.FirstOrDefault(ativ => ativ.Id.Equals(id));
            else return new Ticket();
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var ticket = _context.Ticket.FirstOrDefault(ativ => ativ.Id.Equals(id));

            if (ticket == null) new Exception("Você está tentando deletar um ticket que não existe");

            _context.Remove(ticket);

            return _context.SaveChanges() > 0;
        }
    }
}