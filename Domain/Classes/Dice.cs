using Domain.Interfaces;

namespace Domain.Classes
{
    public class Dice : IDice
    {
        private static readonly Random Random = new();
        private const int MinimumValue = 1;
        private const int MaximumValue = 6;

        public int Roll()
        {
            return Random.Next(MinimumValue, MaximumValue);
        }
    }
}