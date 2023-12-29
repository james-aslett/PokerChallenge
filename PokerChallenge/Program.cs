
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

        Dictionary<char, int> cardScores = new()
        {
                {'1', 1},
                {'2', 2},
                {'3', 3},
                {'4', 4},
                {'5', 5},
                {'6', 6},
                {'7', 7},
                {'8', 8},
                {'9', 9},
                {'T', 10},
                {'J', 11},
                {'Q', 12},
                {'K', 13},
                {'A', 14}
            };

        foreach (var card in playerOneCards)
        {
            if (cardScores.TryGetValue(card[0], out int score))
            {
                playerOneScore += score;
            }
        }

        foreach (var card in playerTwoCards)
        {
            if (cardScores.TryGetValue(card[0], out int score))
            {
                playerTwoScore += score;
            }
        }

        if (playerOneScore == playerTwoScore)
        {

        }

        return (playerOneScore > playerTwoScore) ? Player.PlayerOne : Player.PlayerTwo;



        //run same test on each player, starting with highest value hand - if one has it, they win
        //if neither have it, test for the next value hand
        //if it's a draw, do a test for highest card

        //int tens = playerOneCards.SelectMany(x => x).Count(c => c == 'T');
        //int jokers = playerOneCards.SelectMany(x => x).Count(c => c == 'J');
        //int queens = playerOneCards.SelectMany(x => x).Count(c => c == 'Q');
        //int kings = playerOneCards.SelectMany(x => x).Count(c => c == 'K');
        //int aces = playerOneCards.SelectMany(x => x).Count(c => c == 'A');

        ////royal flush
        //if (tens > 0 && jokers > 0 && queens > 0 && kings > 0 && aces > 0)
        //{
        //    playerOneScore = 10;
        //}
        ////straight flush - all cards in sequential order (asc/desc) (1st char) and same suit (2nd char)
        //if (1 == 1)
        //{
        //    playerOneScore = 9;
        //}
        ////four of a kind - 4 cards are same value (1st char) 
        //if (1 == 1)
        //{
        //    playerOneScore = 8;
        //}
        ////full house - three of a kind AND a pair
        //if (1 == 1)
        //{
        //    playerOneScore = 7;
        //}
        ////flush - all cards are same suit (2nd char)
        //if (1 == 1)
        //{
        //    playerOneScore = 6;
        //}
        ////straight - all cards in sequential order (asc/desc) (1st char)
        //if (1 == 1)
        //{
        //    playerOneScore = 5;
        //}
        ////three of a kind - three cards of same value (1st char)
        //if (1 == 1)
        //{
        //    playerOneScore = 5;
        //}
        ////two pairs - two different pairs (1st char)
        //if (1 == 1)
        //{
        //    playerOneScore = 4;
        //}
        ////one pair - two cards of same value (1st char)
        //if (1 == 1)
        //{
        //    playerOneScore = 3;
        //}
        ////high card - highest value card
        //if (1 == 1)
        //{
        //    playerOneScore = 2; //whatever the highest value is
        //}

    }

    public enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}