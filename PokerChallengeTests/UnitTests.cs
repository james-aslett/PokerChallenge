using static PokerChallenge.Program;
using static PokerChallenge.Ranks;

namespace PokerChallengeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoyalFlush()
        {
            var cards = new[] { "TC", "JH", "QD", "KH", "AH" };
            var result = HasRoyalFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NoRoyalFlush()
        {
            var cards = new[] { "9C", "JH", "QD", "KH", "AH" };
            var result = HasRoyalFlush(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void StraightFlush()
        {
            var cards = new[] { "2C", "3C", "4C", "5C", "6C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void StraightFlushReverse()
        {
            var cards = new[] { "6C", "5C", "4C", "3C", "2C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void NoStraightFlush()
        {
            var cards = new[] { "2C", "3C", "4D", "5C", "6C" };
            var result = HasStraightFlush(cards);
            Assert.That(result, Is.EqualTo(false));
        }

        //[Test]
        //public void PlayerTwoHighestValueWins()
        //{
        //    var players = new[] { new[] { "1H", "2H", "3H", "4H", "5H" }, new[] { "6H", "7H", "8H", "9H", "TH" } };
        //    var winner = DetermineWinner(players);
        //    Assert.That(winner, Is.EqualTo(Player.PlayerTwo));
        //}
    }
}