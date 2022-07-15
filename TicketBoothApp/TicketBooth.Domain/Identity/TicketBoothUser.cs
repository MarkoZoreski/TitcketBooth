using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Domain.Identity
{
    public class TicketBoothUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Cart Cart { get; set; }
        
    }
}
