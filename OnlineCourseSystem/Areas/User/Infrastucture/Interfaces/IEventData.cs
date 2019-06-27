using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Infrastucture.Interfaces
{
    public interface IEventData
    {
        IEnumerable<Event> GetEvents();
        int EventsCount();
        Event AddEvent(Event eventModel);
        IEnumerable<Event> GetEventsWithOrganizer();
        Event GetEvent(int id);
        void UpdateEvent(Event eventModel);
        void DeleteEvent(Event eventModel);
        IEnumerable<Event> GetFiveRandomEvents();
    }
}
