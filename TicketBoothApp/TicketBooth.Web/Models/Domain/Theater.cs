using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooth.Web.Models.Domain
{
    public class Theater : BaseEntity
    {

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int MaxSeats { get; set; }

        [Required]
        public double Price { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public virtual List<Ticket> Tickets { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return String.Format("{0} , Movie: {1}", Date.ToString(), Movie.Name);
        }
    }
}
