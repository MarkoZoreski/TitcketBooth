using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Repository.Interface
{
    public interface ITheaterRepository
    {
        List<Theater> GetAll();
        Theater Get(Guid? id);
        void Insert(Theater entity);
        void Update(Theater entity);
        void Delete(Theater entity);
    }
}
