using Domain.Interfaces;

namespace Domain.Classes
{
    public class Player
    {
        public Guid Id { get; }
        public int Position { get; set; }
        public int MaxPosition { get; }
        public IDice Dice { get; }

        public Player(IDice dice, int maxPosition)
        {
            Dice = dice;
            MaxPosition = maxPosition;
            Id = Guid.NewGuid();
            Position = 1;
        }

        public int PlayTurn()
        {
            int diceResult = Dice.Roll();
            Move(diceResult);
            return diceResult;
        }

        public void Move(int squares)
        {
            int newPosition = Position + squares;
            if (newPosition <= MaxPosition)
                Position = newPosition;
        }
    }
}