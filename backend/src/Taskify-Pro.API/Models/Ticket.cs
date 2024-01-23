using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taskify_Pro.API.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }

        public Ticket() {}
        public Ticket(int id) { this.Id = id;}
    }
}