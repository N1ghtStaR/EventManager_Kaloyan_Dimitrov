using Event_Manager_DB.Entities;
using PrimeHolding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeHolding.Factory.EventsFactory
{
    public class EventFactory : IEventFactory
    {
        public Event AddEventModel(EventViewModel _model)
        {
            Event model = new Event
            {
                ID = _model.ID,
                Name = _model.Name,
                Location = _model.Location,
                Start = _model.Start,
                Finish = _model.Finish
            };

            return model;
        }

        public EventViewModel AddEventViewModel(Event _model)
        {
            EventViewModel model = new EventViewModel
            {
                ID = _model.ID,
                Name = _model.Name,
                Location = _model.Location,
                Start = _model.Start,
                Finish = _model.Finish
            };

            return model;

        }
    }
}