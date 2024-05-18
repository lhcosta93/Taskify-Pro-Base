using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskify_Pro.Domain.Entities;
using Taskify_Pro.Domain.Interfaces.Repositories;
using Taskify_Pro.Domain.Interfaces.Services;

namespace Taskify_Pro.Domain.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketService(ITicketRepo ticketRepo)
        {

            this._ticketRepo = ticketRepo;

        }
        public async Task<Ticket> addTicket(Ticket ticket)
        {
            if (await _ticketRepo.getByTitleAsync(ticket.Title) != null)
                throw new Exception("Já existe um ticket com esse título");

            if (await _ticketRepo.getByIDAsync(ticket.Id) == null)
            {
                _ticketRepo.Add(ticket);
                if (await _ticketRepo.SaveChangesAsync())
                    return ticket;
            }

            return null;
        }

        public async Task<bool> deleteTicket(int Id)
        {
            var ticket = await _ticketRepo.getByIDAsync(Id);
            if (ticket == null) throw new Exception("Atividade que tentou deletar não existe");

            _ticketRepo.Delete(ticket);
            return await _ticketRepo.SaveChangesAsync();
        }

        public async Task<bool> fineshTicket(Ticket ticket)
        {
            if (ticket != null)
            {
                ticket.Finish();
                _ticketRepo.Update<Ticket>(ticket);
                return await _ticketRepo.SaveChangesAsync();
            }

            return false;
        }

        public async Task<Ticket[]> getAllTicketAsync()
        {
            try
            {
                return await _ticketRepo.getAllAsync();
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket> getTicketByIdAsync(int Id)
        {
            try
            {
                return await _ticketRepo.getByIDAsync(Id);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ticket> updateTicket(Ticket ticket)
        {
            if (ticket.DateFinished != null)
                throw new Exception("Não se pode alterar atividade já concluída.");

            if (await _ticketRepo.getByIDAsync(ticket.Id) != null)
            {
                _ticketRepo.Update(ticket);
                if (await _ticketRepo.SaveChangesAsync())
                    return ticket;
            }

            return null;
        }
    }
}