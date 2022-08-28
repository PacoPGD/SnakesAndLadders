using Domain.Interfaces;

namespace Domain.Classes
{
    public class Game : IGame
    {
        public List<Player> Players = new();

        private const int MinimumPlayers = 2;
        private const int MaximumPlayers = 6;
        private const int MaxPosition = 100;

        private int _playerTurn;

        public bool StartGame(int players, IDice dice)
        {
            if (players is < MinimumPlayers or > MaximumPlayers)
                return false;

            for (int i = 0; i < players; i++)
                Players.Add(new Player(dice, MaxPosition));

            return true;
        }

        public int PlayTurn()
        {
            return Players[_playerTurn].PlayTurn();
        }

        public int GetPlayerTurn()
        {
            return _playerTurn + 1;
        }

        public void ChangeTurn()
        {
            _playerTurn += 1;

            if (_playerTurn == Players.Count)
            {
                _playerTurn = 0;
            }
        }

        public int GetCurrentPlayerPosition()
        {
            return Players[_playerTurn].Position;
        }

        public bool IsGameCompleted()
        {
            return Players.Any(x => x.Position == MaxPosition);
        }

        public Guid GetWinner()
        {
            var winner = Players.FirstOrDefault(x => x.Position == MaxPosition);
            return winner?.Id ?? Guid.Empty;
        }
    }
}