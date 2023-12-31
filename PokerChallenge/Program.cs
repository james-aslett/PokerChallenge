using static PokerChallenge.Cards;

namespace PokerChallenge;

public class Program
{
    public static void Main()
    {
        var playerOneWinCount = PlayGame(File.ReadLines("poker_hands.txt"));
        Console.WriteLine($"Player 1 won {playerOneWinCount} times.");

    }

    public static int PlayGame(IEnumerable<string> hands)
    {
        var playerOneWinCount = 0;

        foreach (var hand in hands)
        {
            var players = SplitPlayers(hand);
            var winner = DetermineWinner(players);
            if (winner == Player.PlayerOne)
            {
                playerOneWinCount++;
            }
        }

        return playerOneWinCount;
    }

    private static string[][] SplitPlayers(string hand)
    {
        var cleanHands = hand.Replace(" ", "");
        var player1 = PlayerHandsToArray(cleanHands[..10]);
        var player2 = PlayerHandsToArray(cleanHands[10..]);
        return new[] { player1, player2 };
    }

    private static string[] PlayerHandsToArray(string player)
    {
        var playerArray = new string[player.Length / 2];
        for (var i = 0; i < player.Length; i += 2)
        {
            playerArray[i / 2] = player.Substring(i, 2);
        }

        return playerArray;
    }

    public static Player DetermineWinner(string[][] players)
    {
        var playerOneCards = players[0];
        var playerTwoCards = players[1];

        var playerOne = CalculateScore(playerOneCards);
        var playerTwo = CalculateScore(playerTwoCards);

        var playerOneScore = playerOne.score;
        var playerTwoScore = playerTwo.score;
        var playerOneIncludesPairs = playerOne.includesPairs;
        var playerTwoIncludesPairs = playerTwo.includesPairs;

        if (playerOneScore == playerTwoScore)
        {
            playerOneScore = GetHighCard(playerOneCards, playerOneIncludesPairs);
            playerTwoScore = GetHighCard(playerTwoCards, playerTwoIncludesPairs);

        }

        return (playerOneScore > playerTwoScore) ? Player.PlayerOne : Player.PlayerTwo;
    }

    private static (int score, bool includesPairs) CalculateScore(string[] cards)
    {
        if (HasRoyalFlush(cards)) return (10, false);
        if (HasStraightFlush(cards)) return (9, false);
        if (HasFourOfAKind(cards)) return (8, false);
        if (HasFullHouse(cards)) return (7, false);
        if (HasFlush(cards)) return (6, false);
        if (HasStraight(cards)) return (5, false);
        if (HasThreeOfAKind(cards)) return (4, false);
        if (HasTwoPairs(cards)) return (3, true);
        if (HasOnePair(cards)) return (2, true);

        return (0, false);
    }


    public enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}