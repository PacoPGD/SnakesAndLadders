using Domain.Classes;
using Domain.Interfaces;
using Xunit;

namespace Domain.UnitTests
{
    public class PlayerTests
    {
        private readonly IDice _dice = new Dice();
        private readonly int _maxPosition = 100;

        /*Given the token is on square 1
        When the token is moved 3 spaces
        Then the token is on square 4*/
        [Fact]
        public void When_PlayerStartIn1_And_PlayerMove3_PositionIs4()
        {
            const int expectedPosition = 4;

            var player = new Player(_dice, _maxPosition);

            player.Move(3);
            Assert.Equal(expectedPosition, player.Position);
        }

        /*Given the token is on square 1
        When the token is moved 3 spaces
        And then it is moved 4 spaces
        Then the token is on square 8*/
        [Fact]
        public void When_PlayerStartIn1_And_PlayerMove3_And_PlayerMove4_PositionIs8()
        {
            const int expectedPosition = 8;

            var player = new Player(_dice, _maxPosition);

            player.Move(3);
            player.Move(4);
            Assert.Equal(expectedPosition, player.Position);
        }
    }
}