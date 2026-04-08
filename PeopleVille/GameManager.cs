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
                World.globalLogger.LogEvent(null, "---- Tick ----");
                await Task.Delay(500);
            }
        }
    }
}