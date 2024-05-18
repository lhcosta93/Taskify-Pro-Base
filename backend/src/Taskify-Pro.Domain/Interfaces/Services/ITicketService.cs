using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskify_Pro.Domain.Entities;

namespace Taskify_Pro.Domain.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Ticket> addTicket(Ticket ticket);
        Task<Ticket> updateTicket(Ticket ticket);
        Task<bool> deleteTicket(int Id);
        Task<bool> fineshTicket(Ticket ticket);
        Task<Ticket[]> getAllTicketAsync();
        Task<Ticket> getTicketByIdAsync(int Id);        
    }
}