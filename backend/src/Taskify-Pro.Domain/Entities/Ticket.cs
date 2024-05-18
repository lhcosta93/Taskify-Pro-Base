using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskify_Pro.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateFinished { get; set; }

        public Ticket()
        {
            DateCreated = DateTime.Now;
            DateFinished = null;
        }
        public Ticket(int id, string title, string description) : this()
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }

        public void Finish()
        {
            if (DateFinished == null) DateFinished = DateTime.Now;
            else throw new Exception($"Atividade já concluída em: {DateFinished?.ToString("dd/MM/yyyy hh:mm")}");
        }
    }
}