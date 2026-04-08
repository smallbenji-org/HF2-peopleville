using System.Collections.Concurrent;
using PeopleVille.Persons;

namespace PeopleVille
{
    public class GlobalLogger
    {
        public ConcurrentDictionary<Person, ConcurrentQueue<LogEvent>> PersonLog = [];
        public event Action<LogEvent> LogAdded;

        public void LogEvent(Person person, string eventText)
        {
            var logEvent = new LogEvent()
            {
                Person = person,
                EventText = eventText
            };

            if (person != null)
            {
                var log = PersonLog.GetOrAdd(person, _ => new ConcurrentQueue<LogEvent>());
                log.Enqueue(logEvent);
            }

            LogAdded?.Invoke(logEvent);
        }
    }

    public class LogEvent
    {
        public Person Person { get; set; }
        public DateTime EventTime { get; set; } = DateTime.Now;
        public string EventText { get; set; }
    }
}