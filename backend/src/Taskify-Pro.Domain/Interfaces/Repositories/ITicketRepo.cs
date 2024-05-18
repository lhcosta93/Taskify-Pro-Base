using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskify_Pro.Domain.Entities;

namespace Taskify_Pro.Domain.Interfaces.Repositories
{
    public interface ITicketRepo : IGeneralRepo
    {
        Task<Ticket[]> getAllAsync();
        Task<Ticket> getByIDAsync(int id);
        Task<Ticket> getByTitleAsync(string title);
    }
}