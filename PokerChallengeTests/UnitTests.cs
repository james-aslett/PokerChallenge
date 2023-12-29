using PokerChallenge;

namespace PokerChallengeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlayerOneHighestValueWins()
        {
            var players = new[] { new[] { "6H", "7H", "8H", "9H", "TH" }, new[] { "1H", "2H", "3H", "4H", "5H" } };
            var winner = Program.DetermineWinner(players);
            Assert.That(winner, Is.EqualTo(Program.Player.PlayerOne));
        }

        [Test]
        public void PlayerTwoHighestValueWins()
        {
            var players = new[] { new[] { "1H", "2H", "3H", "4H", "5H" }, new[] { "6H", "7H", "8H", "9H", "TH" } };
            var winner = Program.DetermineWinner(players);
            Assert.That(winner, Is.EqualTo(Program.Player.PlayerTwo));
        }
    }
}