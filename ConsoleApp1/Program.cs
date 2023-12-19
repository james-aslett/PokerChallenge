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

        






        //if PlayerOne wins, return Player.PlayerOne, else return Player.PlayerTwo
        return Player.PlayerOne;
    }

    private enum Player
    {
        PlayerOne,
        PlayerTwo
    }
}