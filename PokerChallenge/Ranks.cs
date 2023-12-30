
namespace PokerChallenge
{
    public class Ranks
    {
        public static int GetHighCard(string[] cards)
        {
            var playerScore = 0;

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

            foreach (var card in cards)
            {
                if (cardScores.TryGetValue(card[0], out int score))
                {
                    playerScore += score;
                }
            }

            return playerScore;
        }

        public static bool HasStraightFlush(string[] cards)
        {
            //straight flush - all cards in sequential order (asc/desc) (1st char) and same suit (2nd char)
            throw new NotImplementedException();
        }

        public static bool HasFourOfAKind(string[] cards)
        {
            ////four of a kind - 4 cards are same value (1st char)
            throw new NotImplementedException();
        }

        public static bool HasFullHouse(string[] cards)
        {
            ////full house - three of a kind AND a pair
            throw new NotImplementedException();
        }

        public static bool HasFlush(string[] cards)
        {
            ////flush - all cards are same suit (2nd char)
            throw new NotImplementedException();
        }

        public static bool HasStraight(string[] cards)
        {
            ////straight - all cards in sequential order (asc/desc) (1st char)
            throw new NotImplementedException();
        }

        public static bool HasThreeOfAKind(string[] cards)
        {
            ////three of a kind - three cards of same value (1st char)
            throw new NotImplementedException();
        }

        public static bool HasTwoPairs(string[] cards)
        {
            ////two pairs - two different pairs (1st char)
            throw new NotImplementedException();
        }
        public static bool HasOnePair(string[] cards)
        {
            ////one pair - two cards of same value (1st char)
            throw new NotImplementedException();
        }

       public static bool HasRoyalFlush(string[] cards)
        {
            int tens = cards.SelectMany(x => x).Count(c => c == 'T');
            int jokers = cards.SelectMany(x => x).Count(c => c == 'J');
            int queens = cards.SelectMany(x => x).Count(c => c == 'Q');
            int kings = cards.SelectMany(x => x).Count(c => c == 'K');
            int aces = cards.SelectMany(x => x).Count(c => c == 'A');
            if (tens > 0 && jokers > 0 && queens > 0 && kings > 0 && aces > 0)
            {
                return true;
            }
            return false;
        }
    }
}
