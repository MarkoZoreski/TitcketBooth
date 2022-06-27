using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooth.Web.Models.Domain
{
    public class Movie : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }

        [Required]
        public string MovieGenre { get; set; }

        [Required]
        public string MovieImage { get; set; }

        [Required]
        public string MovieDescription { get; set; }

        public virtual List<Theater> Theaters { get; set; }

        public override string ToString()
        {
            return MovieName;
        }
    }
}
