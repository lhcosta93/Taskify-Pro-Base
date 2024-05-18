using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Taskify_Pro.Data.Context;
using Taskify_Pro.Domain.Entities;
using Taskify_Pro.Domain.Interfaces.Repositories;

namespace Taskify_Pro.Data.Repositories
{
    public class TicketRepo : GeneralRepo, ITicketRepo
    {
        private  readonly DataContext _context;
        public TicketRepo(DataContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<Ticket[]> getAllAsync()
        {
            IQueryable<Ticket> query = _context.Ticket;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Ticket> getByIDAsync(int id)
        {
            IQueryable<Ticket> query = _context.Ticket;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Id)
                         .Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Ticket> getByTitleAsync(string title)
        {
            IQueryable<Ticket> query = _context.Ticket;

            query = query.AsNoTracking()
                         .OrderBy(x => x.Title)
                         .Where(x => x.Title == title);

            return await query.FirstOrDefaultAsync();
        }
    }
}