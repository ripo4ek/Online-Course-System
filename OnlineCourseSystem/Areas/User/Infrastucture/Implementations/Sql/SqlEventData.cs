using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineCourseSystem.Areas.User.Infrastucture.Interfaces;
using OnlineCourseSystem.DAL.Context;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Implementations.Sql
{
    public class SqlEventData : IEventData
    {
        private readonly OnlineCourseSystemContext _context;

        public SqlEventData(OnlineCourseSystemContext context)
        {
            _context = context;
        }
        public Event AddEvent(Event eventModel)
        {
            _context.Events.Add(eventModel);
            _context.SaveChanges();
            return eventModel;
        }

        public void DeleteEvent(Event eventModel)
        {
            _context.Events.Remove(eventModel);
            _context.SaveChanges();
        }

        public int EventsCount()
        {
           return _context.Events.Count();
        }

        public Event GetEvent(int id)
        {
            return _context.Events.Include(e => e.Organizer).First(e => e.Id == id);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _context.Events.Include(e => e.Organizer);
        }

        public IEnumerable<Event> GetEventsWithOrganizer()
        {
            return _context.Events.Include(a => a.Organizer);
        }

        public IEnumerable<Event> GetFiveRandomEvents()
        {
            return _context.Events.Take(5);
        }

        public void UpdateEvent(Event eventModel)
        {
            _context.Events.Update(eventModel);
            _context.SaveChanges();
        }
    }
}
