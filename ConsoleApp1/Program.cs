using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

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
        var one = players[0];
        var two = players[1];

        //Suits: D/C/H/S
        //Values (low > high): 2/3/4/5/6/7/8/9/10(T)J/Q/K/A
        int p1Score = 0;

        int diamonds = one.SelectMany(x => x).Count(c => c == 'D');
        int clubs = one.SelectMany(x => x).Count(c => c == 'C');
        int hearts = one.SelectMany(x => x).Count(c => c == 'H');
        int spades = one.SelectMany(x => x).Count(c => c == 'S');

        int tens = one.SelectMany(x => x).Count(c => c == 'T');
        int jokers = one.SelectMany(x => x).Count(c => c == 'J');
        int queens = one.SelectMany(x => x).Count(c => c == 'Q');
        int kings = one.SelectMany(x => x).Count(c => c == 'K');
        int aces = one.SelectMany(x => x).Count(c => c == 'A');

        if (tens > 0 && jokers > 0 && queens > 0 && kings > 0 && aces > 0)
        {
            //royal flush
            p1Score = 10;
        }

        //scores
        //high card 1
        //one pair 2
        //two pairs 3
        //three of a kind 4
        //straight 5
        //flush 6
        //full house 7
        //four of a kind 8
        //straight flush 9

        //once p1Score/p2Score is known, if they match then 

        return (p1Score > 0) ? Player.PlayerOne : Player.PlayerTwo;
    }

    private enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}