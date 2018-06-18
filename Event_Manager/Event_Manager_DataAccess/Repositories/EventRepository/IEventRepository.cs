using Event_Manager_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager_DataAccess.Repositories.EventRepository
{
    interface IEventRepository : IDisposable
    {
        IEnumerable<Event> GetEvents();
        Event GetEventByID(int id);
        void AddEvent(Event _event);
        void EditEvent(Event _event);
        void DeleteEvent(Event _event);
        void Save();
    }
}
