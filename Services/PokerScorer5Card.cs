using System.Collections.Generic;
using System.Linq;

namespace CsharpPokerFunctional
{
    public static class PokerScorer5Card
    {
        public static HandRank GetHandRank(this IEnumerable<Card> cards) =>
            ContainsRoyalFlush(cards) ? HandRank.RoyalFlush :
            ContainsFlush(cards) && ContainsStraight(cards) ? HandRank.StraightFlush :
            ContainsFlush(cards) ? HandRank.Flush :
            ContainsFullHouse(cards) ? HandRank.FullHouse :
            ContainsStraight(cards) ? HandRank.Straight :
            HasKOfNCardsOfAKind(cards, 1, 4) ? HandRank.FourOfAKind :
            HasKOfNCardsOfAKind(cards, 1, 3) ? HandRank.ThreeOfAKind :
            HasKOfNCardsOfAKind(cards, 2, 2) ? HandRank.TwoPair :
            HasKOfNCardsOfAKind(cards, 1, 2) ? HandRank.Pair :
            HandRank.HighCard;

        private static bool ContainsStraight(IEnumerable<Card> cards) => cards.OrderBy(c => c.Value)
            .SelectConsecutive((c1, c2) => c1.Value + 1 == c2.Value)
            .All(c => c);

        private static bool HasKOfNCardsOfAKind(IEnumerable<Card> cards, int k, int n) =>
            cards.GroupBy(c => c.Value)
                .Count(g => g.Count() == n) == k;

        private static bool ContainsRoyalFlush(IEnumerable<Card> cards) =>
            ContainsFlush(cards) && cards.All(c => c.Value > CardValue.Nine);

        private static bool ContainsFullHouse(IEnumerable<Card> cards) =>
            HasKOfNCardsOfAKind(cards, 1, 3) && HasKOfNCardsOfAKind(cards, 1, 2);

        private static bool ContainsFlush(IEnumerable<Card> cards) =>
            cards.All(c => cards.First().Suit == c.Suit);

        public static CardValue GetHighCard(this IEnumerable<Card> cards) => cards.Max((card) => card.Value);
    }
}