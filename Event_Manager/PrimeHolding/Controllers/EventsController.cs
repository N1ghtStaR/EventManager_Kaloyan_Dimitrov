using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Event_Manager_DataAccess.Repositories;
using Event_Manager_DB;
using Event_Manager_DB.Entities;
using PrimeHolding.Factory;
using PrimeHolding.Models;

namespace PrimeHolding.Controllers
{
    public class EventsController : Controller
    {
        private readonly Factoring _factory;
        private readonly UnitOfWork _uow;

        public EventsController()
        {
            _uow = new UnitOfWork(new Event_Manager_DbContext());
            _factory = new Factoring();
        }

        public EventsController(Event_Manager_DbContext _context)
        {
            _uow = new UnitOfWork(_context);
        }

        public ActionResult Index()
        {
            IEnumerable<Event> events = _uow.EventRepository.GetEvents();

            List<EventViewModel> model = new List<EventViewModel>();

            foreach(Event _event in events)
            {
                EventViewModel _model = _factory.EventFactory.AddEventViewModel(_event);
                model.Add(_model);
            }

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event _event = _uow.EventRepository.GetEventByID((int)id);

            if (_event == null)
            {
                return HttpNotFound();
            }

            EventViewModel _model = _factory.EventFactory.AddEventViewModel(_event);

            return View(_model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location,Start,Finish")] EventViewModel _model)
        {
            if (ModelState.IsValid)
            {
                Event _event = _factory.EventFactory.AddEventModel(_model);

                _uow.EventRepository.AddEvent(_event);
                _uow.EventRepository.Save();

                return RedirectToAction("Index");
            }

            return View(_model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event _event = _uow.EventRepository.GetEventByID((int)id);

            if (_event == null)
            {
                return HttpNotFound();
            }

            EventViewModel _model = _factory.EventFactory.AddEventViewModel(_event);

            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,Start,Finish")] EventViewModel _model)
        {
            if (ModelState.IsValid)
            {
                Event _event = _factory.EventFactory.AddEventModel(_model);

                _uow.EventRepository.EditEvent(_event);
                _uow.EventRepository.Save();
                return RedirectToAction("Index");
            }
            return View(_model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event _event = _uow.EventRepository.GetEventByID((int)id);

            if (_event == null)
            {
                return HttpNotFound();
            }

            EventViewModel _model = _factory.EventFactory.AddEventViewModel(_event);

            return View(_model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event _event = _uow.EventRepository.GetEventByID(id);

            _uow.EventRepository.DeleteEvent(_event);
            _uow.EventRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.EventRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
