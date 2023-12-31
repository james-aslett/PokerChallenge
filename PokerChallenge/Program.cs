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

        var playerOneScore = CalculateScore(playerOneCards);
        var playerTwoScore = CalculateScore(playerTwoCards);

        if (playerOneScore == playerTwoScore)
        {
            //implement tiebreaker logic

            // For example, if both players have a pair, compare the pair ranks

            // If pairs are of the same rank, compare the high card ranks
            // Implement similar logic for other hand types

        }

        return (playerOneScore > playerTwoScore) ? Player.PlayerOne : Player.PlayerTwo;
    }

    private static int CalculateScore(string[] cards)
    {
        if (HasRoyalFlush(cards)) return 10;
        if (HasStraightFlush(cards)) return 9;
        if (HasFourOfAKind(cards)) return 8;
        if (HasFullHouse(cards)) return 7;
        if (HasFlush(cards)) return 6;
        if (HasStraight(cards)) return 5;
        if (HasThreeOfAKind(cards)) return 4;
        if (HasTwoPairs(cards)) return 3;
        if (HasOnePair(cards)) return 2;

        return 0;
    }

    public enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}