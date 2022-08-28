namespace Domain.Interfaces
{
    public interface IGame
    {
        bool StartGame(int players, IDice dice);
        int PlayTurn();
        int GetPlayerTurn();
        void ChangeTurn();
        int GetCurrentPlayerPosition();
        bool IsGameCompleted();
        Guid GetWinner();
    }
}