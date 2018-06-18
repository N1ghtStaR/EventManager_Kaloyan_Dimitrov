using Event_Manager_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Manager_DataAccess.Repositories
{
    public class UnitOfWork
    {
        private readonly Event_Manager_DbContext _context;
        private EventRepository.EventRepository _eventRepo;

        public UnitOfWork(Event_Manager_DbContext _context)
        {
            this._context = _context;
        }

        public EventRepository.EventRepository EventRepository
        {
            get
            {
                if(_eventRepo == null)
                {
                    _eventRepo = new EventRepository.EventRepository(_context);
                }

                return _eventRepo;
            }
        }
    }
}
