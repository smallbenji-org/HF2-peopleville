using PeopleVille.WorldBuilder;

namespace PeopleVille
{
    public class GameManager
    {
        public delegate void TickHandler();

        public event TickHandler TickDone;
        public World World { get; set; }

        public async Task StartClock()
        {
            while (true)
            {
                TickDone.Invoke();
                // This need to be fixed, somehow, maybe a global log method?
                var loggerPerson = World?.People.FirstOrDefault();
                if (loggerPerson != null)
                {
                    World.globalLogger.LogEvent(loggerPerson, "---- Tick ----");
                }
                await Task.Delay(500);
            }
        }
    }
}