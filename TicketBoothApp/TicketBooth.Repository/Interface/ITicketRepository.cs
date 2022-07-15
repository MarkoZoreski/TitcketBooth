using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Repository.Interface
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket Get(Guid? id);
        void Insert(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
    }
}
