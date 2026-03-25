using PeopleVille.Location;

namespace PeopleVille
{
    public class GameManager
    {
        List<Store> Stores { get; set; }

        public async Task StartClock()
        {
            var res = 0;

            while (true)
            {
                Console.WriteLine($"{res}");
                res++;
                // Do something
                await Task.Delay(500);
            }
        }
    }
}