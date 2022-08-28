using Domain.Classes;
using Xunit;

namespace Domain.UnitTests
{
    public class DiceTests
    {
        /*Given the game is started
        When the player rolls a die
        Then the result should be between 1-6 inclusive*/
        [Fact]
        public void When_DiceRolls_Expect_Between1And6()
        {
            const int minExpected = 1;
            const int maxExpected = 6;

            Dice dice = new();

            Assert.True(dice.Roll() >= minExpected);
            Assert.True(dice.Roll() <= maxExpected);
        }
    }
}