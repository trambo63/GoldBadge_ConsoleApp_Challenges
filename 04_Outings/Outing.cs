using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert}
    public class Outing
    {
        public EventType EventType { get; set; }
        public int NumberOfAttendees { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEvent { get; set; }

        public Outing() { }
        public Outing(EventType eventType, int numberOfAttendees, DateTime date, double costPerPerson, double costOfEvent)
        {
            EventType = eventType;
            NumberOfAttendees = numberOfAttendees;
            Date = date;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }
    }
    
}
