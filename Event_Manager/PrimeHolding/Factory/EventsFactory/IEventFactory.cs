using Event_Manager_DB.Entities;
using PrimeHolding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeHolding.Factory.EventsFactory
{
    interface IEventFactory
    {
        Event AddEventModel(EventViewModel _model);
        EventViewModel AddEventViewModel(Event _model);
    }
}
