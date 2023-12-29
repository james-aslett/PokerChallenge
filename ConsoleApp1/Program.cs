
namespace ConsoleApp1;

internal class Program
{
    private static void Main()
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

    private static Player DetermineWinner(string[][] players)
    {
        var playerOneCards = players[0];
        var playerTwoCards = players[1];

        int playerOneScore = 0;
        int playerTwoScore = 0;

        int tens = playerOneCards.SelectMany(x => x).Count(c => c == 'T');
        int jokers = playerOneCards.SelectMany(x => x).Count(c => c == 'J');
        int queens = playerOneCards.SelectMany(x => x).Count(c => c == 'Q');
        int kings = playerOneCards.SelectMany(x => x).Count(c => c == 'K');
        int aces = playerOneCards.SelectMany(x => x).Count(c => c == 'A');

        //royal flush
        if (tens > 0 && jokers > 0 && queens > 0 && kings > 0 && aces > 0)
        {
            playerOneScore = 10;
        }
        //straight flush - all cards in sequential order (asc/desc) (1st char) and same suit (2nd char)
        if (1 == 1)
        {
            playerOneScore = 9;
        }
        //four of a kind - 4 cards are same value (1st char) 
        if (1 == 1)
        {
            playerOneScore = 8;
        }
        //full house - three of a kind AND a pair
        if (1 == 1)
        {
            playerOneScore = 7;
        }
        //flush - all cards are same suit (2nd char)
        if (1 == 1)
        {
            playerOneScore = 6;
        }
        //straight - all cards in sequential order (asc/desc) (1st char)
        if (1 == 1)
        {
            playerOneScore = 5;
        }
        //three of a kind - three cards of same value (1st char)
        if (1 == 1)
        {
            playerOneScore = 5;
        }
        //two pairs - two different pairs (1st char)
        if (1 == 1)
        {
            playerOneScore = 4;
        }
        //one pair - two cards of same value (1st char)
        if (1 == 1)
        {
            playerOneScore = 3;
        }
        //high card - highest value card
        if (1 == 1)
        {
            playerOneScore = 2; //whatever the highest value is
        }

        return (playerOneScore > 0) ? Player.PlayerOne : Player.PlayerTwo;
    }

    private enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}