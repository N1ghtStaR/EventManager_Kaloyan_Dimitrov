using PrimeHolding.Factory.EventsFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimeHolding.Factory
{
    public class Factoring
    {
        private EventFactory _eventFact;

        public EventFactory EventFactory
        {
            get
            {
                if(_eventFact == null)
                {
                    _eventFact = new EventFactory();
                }

                return _eventFact;
            }
        }

    }
}