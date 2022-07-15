using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.Identity;

namespace TicketBooth.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<TicketBoothUser> GetAll();
        TicketBoothUser Get(string username);
        void Insert(TicketBoothUser entity);
        void Update(TicketBoothUser entity);
        void Delete(TicketBoothUser entity);
    }
}
