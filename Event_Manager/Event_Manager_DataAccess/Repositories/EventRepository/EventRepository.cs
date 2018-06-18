using Event_Manager_DB;
using Event_Manager_DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager_DataAccess.Repositories.EventRepository
{
    public class EventRepository : IEventRepository, IDisposable
    {
        private readonly Event_Manager_DbContext _context;
        private bool disposed;

        public EventRepository(Event_Manager_DbContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEventByID(int id)
        {
            return _context.Events.Find(id);
        }

        public void AddEvent(Event _event)
        {
            _context.Events.Add(_event);
        }

        public void EditEvent(Event _event)
        {
            _context.Entry(_event).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteEvent(Event _event)
        {
            _context.Events.Remove(_event);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
