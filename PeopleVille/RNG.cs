namespace PeopleVille
{
    public class RNG
    {
        static readonly Random random = new();

        public static int Range(int minVal, int maxVal)
        {
            return random.Next(minVal, maxVal);
        }

        public static int ThrowDice(Die die, int throws = 1)
        {
            var res = 0;

            for (var i = 0; i < throws; i++)
            {
                res += Range(1, die.Sides + 1);
            }

            return res;
        }
    }

    public static class Dices
    {
        public static Die D2 = new(2);
        public static Die D4 = new(4);
        public static Die D6 = new(6);
    }

    public class Die
    {
        public Die(int sides)
        {
            Sides = sides;
        }

        public int Sides { get; set; }
    }
}