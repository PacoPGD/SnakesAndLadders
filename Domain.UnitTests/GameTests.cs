using Domain.Classes;
using Domain.Interfaces;
using Moq;
using Xunit;

namespace Domain.UnitTests
{
    public class GameTests
    {
        private readonly IDice _dice = new Dice();
        private readonly int _minimumPlayers = 2;

        /*Given the game is started
        When the token is placed on the board
        Then the token is on square 1*/
        [Fact]
        public void When_StartGame_PlayerPositionIs1()
        {
            const int initialPosition = 1;

            var game = new Game();

            game.StartGame(_minimumPlayers, _dice);
            Assert.Equal(initialPosition, game.GetCurrentPlayerPosition());
        }

        /*Given the token is on square 97
        When the token is moved 3 spaces
        Then the token is on square 100
        And the player has won the game*/
        [Fact]
        public void When_PlayerInPosition97_And_PlayerMove3_PlayerWin()
        {
            const int initialPosition = 97;
            const int move = 3;

            var game = new Game();
            game.StartGame(_minimumPlayers, _dice);
            game.Players[0].Position = initialPosition;
            game.Players[0].Move(move);
            var winnerGuid = game.GetWinner();

            Assert.Equal(game.Players[0].Id, winnerGuid);
        }

        /*Given the token is on square 97
        When the token is moved 4 spaces
        Then the token is on square 97
        And the player has not won the game*/
        [Fact]
        public void When_PlayerInPosition97_And_PlayerMove4_PlayerNotWin()
        {
            const int initialPosition = 97;
            const int move = 4;

            var game = new Game();
            game.StartGame(_minimumPlayers, _dice);
            game.Players[0].Position = initialPosition;
            game.Players[0].Move(move);
            var winnerGuid = game.GetWinner();

            Assert.Equal(Guid.Empty, winnerGuid);
        }

        /*Given the player rolls a 4
        When they move their token
        Then the token should move 4 spaces*/
        [Fact]
        public void When_PlayerDiceRollIs4_PlayerMove4()
        {
            const int expectedRoll = 4;
            var diceMock = new Mock<IDice>();
            diceMock.Setup(p => p.Roll()).Returns(expectedRoll);

            var game = new Game();
            game.StartGame(_minimumPlayers, diceMock.Object);

            var currentPosition = game.Players[0].Position;
            var expectedPosition = currentPosition + expectedRoll;

            game.PlayTurn();

            Assert.Equal(expectedPosition, game.Players[0].Position);
        }
    }
}
