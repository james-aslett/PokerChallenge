using static PokerChallenge.Ranks;

namespace PokerChallenge;

public class Program
{
    public static void Main()
    {
        var playerOneWinCount = 0;

        var pokerHands = File.ReadLines("poker_hands.txt");
        foreach (var hand in pokerHands)
        {
            var players = SplitPlayers(hand);
            var winner = DetermineWinner(players);
            if (winner == Player.PlayerOne)
            {
                playerOneWinCount++;
            }
        }

        Console.WriteLine($"Player 1 won {playerOneWinCount} times.");
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

        int playerOneScore = 0;
        int playerTwoScore = 0;

        if (HasRoyalFlush(playerOneCards))
        {
            playerOneScore = 10;
        }
        else if (HasStraightFlush(playerOneCards))
        {
            playerOneScore = 9;
        }
        else if (HasFourOfAKind(playerOneCards))
        {
            playerOneScore = 8;
        }
        else if (HasFullHouse(playerOneCards))
        {
            playerOneScore = 7;
        }
        else if (HasFlush(playerOneCards))
        {
            playerOneScore = 6;
        }
        else if (HasStraight(playerOneCards))
        {
            playerOneScore = 5;
        }
        else if (HasThreeOfAKind(playerOneCards))
        {
            playerOneScore = 4;
        }
        else if (HasTwoPairs(playerOneCards))
        {
            playerOneScore = 3;
        }
        else if (HasOnePair(playerOneCards))
        {
            playerOneScore = 2;
        }
        else
        {
            playerOneScore = GetHighCard(playerOneCards);
        }

        return (playerOneScore > playerTwoScore) ? Player.PlayerOne : Player.PlayerTwo;
    }

    public enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}