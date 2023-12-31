﻿
using Microsoft.VisualBasic;
using System;

namespace PokerChallenge
{
    public class Cards
    {
        public static int GetHighCard(string[] cards, bool includesPairs)
        {
            var cardRanks = cards.Select(card => GetCardScore(card)).OrderBy(rank => rank).ToArray();

            if (HasOnePair(cards))
            {


            }

            if (HasTwoPairs(cards))
            {

            }

            //else no pairs - is the above logic correct?

            if (!includesPairs)
            {
                // Exclude pairs
                var excludePairs = cardRanks.Distinct();

                // Get the highest card
                if (excludePairs.Any())
                {
                    return excludePairs.Max();
                }
            }
            var pairs = cardRanks.GroupBy(rank => rank).Where(group => group.Count() == 2).Select(group => group.Key).ToList();


            var x = HasTwoPairs
            // All cards are in pairs, return the highest rank from pairs
            return pairs.Max();
        }

        public static bool HasStraightFlush(string[] cards)
        {
            //all cards in consecutive order (asc/desc) (1st char) and same suit (2nd char)
            var consecutive = HasStraight(cards);
            if (consecutive)
            {
                return HasFlush(cards);
            }

            return false;
        }

        public static bool HasFourOfAKind(string[] cards)
        {
            //4 cards are same value (1st char)
            var cardRanks = cards.Select(card => GetCardScore(card)).ToArray();

            //group each value, then check if any group has a value of 4
            var groups = cardRanks.GroupBy(x => x);

            return groups.Any(group => group.Count() == 4);
        }

        public static bool HasFullHouse(string[] cards)
        {
            //three of a kind AND a pair
            var hasThreeOfAKind = HasThreeOfAKind(cards);
            if (hasThreeOfAKind)
            {
                return HasOnePair(cards);
            }

            return false;
        }

        public static bool HasFlush(string[] cards)
        {
            //all cards are same suit (2nd char)
            var suit = cards[0][1];
            if (cards.Any(card => card[1] != suit))
            {
                return false;
            }

            return true;
        }

        public static bool HasStraight(string[] cards)
        {
            //all cards in consecutive order (asc/desc) (1st char)
            var cardRanks = cards.Select(card => GetCardScore(card)).OrderBy(rank => rank).ToArray();

            //check if cards in consecutive order
            for (int i = 0; i < cardRanks.Length - 1; i++)
            {
                if (cardRanks[i] + 1 != cardRanks[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasThreeOfAKind(string[] cards)
        {
            //3 cards are same value (1st char)
            var cardRanks = cards.Select(card => GetCardScore(card)).OrderBy(rank => rank).ToArray();

            //group each value, then check if any group has a value of 3
            var groups = cardRanks.GroupBy(x => x);

            return groups.Any(group => group.Count() == 3);
        }

        public static bool HasTwoPairs(string[] cards)
        {
            //2 different pairs (1st char)
            var cardRanks = cards.Select(card => GetCardScore(card)).OrderBy(rank => rank).ToArray();

            var groups = cardRanks.GroupBy(x => x);

            // Count the number of groups with a count of 2
            int countOfPairs = groups.Count(group => group.Count() == 2);

            // Only return only if they are 2 distinct pairs
            return countOfPairs == 2;
        }

        public static bool HasOnePair(string[] cards)
        {
            //2 cards of same value (1st char)
            var cardRanks = cards.Select(card => GetCardScore(card)).OrderBy(rank => rank).ToArray();

            //group each value, then check if any group has a value of 2
            var groups = cardRanks.GroupBy(x => x);

            return groups.Any(group => group.Count() == 2);
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

        private static int GetCardScore(string card)
        {
            return card[0] switch
            {
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new ArgumentException($"Invalid card rank: {card[0]}"),
            };
        }
    }
}
