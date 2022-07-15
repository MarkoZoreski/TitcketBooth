using System;
using System.Collections.Generic;
using System.Text;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Service.Interface
{
    public interface ITheaterService
    {
        List<Theater> FindAll();
        List<Theater> FindAllByDate(DateTime date);
        Theater FindById(Guid? id);

        int FindAvailableTickets(Guid id);
        void Create(Theater screaning);
        void Update(Theater screaning);
        void Delete(Guid id);
    }
}
