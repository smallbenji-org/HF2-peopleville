namespace PeopleVille
{
    public class GameManager
    {
        public delegate void TickHandler();

        public event TickHandler TickDone;

        public async Task StartClock()
        {
            while (true)
            {
                Console.WriteLine($"---- Tick ----");
                TickDone.Invoke();
                await Task.Delay(500);
            }
        }
    }
}