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
                TickDone.Invoke();
                await Task.Delay(500);
            }
        }
    }
}