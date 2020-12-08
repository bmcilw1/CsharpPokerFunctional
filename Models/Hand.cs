using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CsharpPokerFunctional
{
    public class Hand : ValueObject
    {
        public HashSet<Card> Cards { get; init; }

        public Hand(HashSet<Card> cards) => Cards = cards;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (Card card in Cards)
                yield return card;
        }

        public HandRank GetHandRank() =>
            !IsFullHand() ? HandRank.NoRank :
            ContainsRoyalFlush() ? HandRank.RoyalFlush :
            ContainsFlush() && ContainsStraight() ? HandRank.StraightFlush :
            ContainsFlush() ? HandRank.Flush :
            ContainsFullHouse() ? HandRank.FullHouse :
            ContainsStraight() ? HandRank.Straight :
            HasNCardsOfAKind(4) ? HandRank.FourOfAKind :
            HasNCardsOfAKind(3) ? HandRank.ThreeOfAKind :
            HasNCardsOfAKind(2) ? HandRank.Pair :
            HandRank.HighCard;

        private bool ContainsStraight() => Cards.OrderBy(c => c.Value)
            .SelectConsecutive((c1, c2) => c1.Value + 1 == c2.Value)
            .All(c => c);

        private bool HasNCardsOfAKind(int n) =>
            Cards.GroupBy(c => c.Value)
                .Where(g => g.Count() > 1)
                .Select(g => new { Value = g.Key, DuplicateCount = g.Count() })
                .OrderByDescending(c => c.DuplicateCount)
                .Any(duplicate => duplicate.DuplicateCount == n);

        private bool IsFullHand() => Cards.Count == 5;

        private bool ContainsRoyalFlush() =>
            ContainsFlush() && Cards.All(c => c.Value > CardValue.Nine);

        private bool ContainsFullHouse() => HasNCardsOfAKind(3) && HasNCardsOfAKind(2);

        private bool ContainsFlush() =>
            Cards.All(c => Cards.First().Suit == c.Suit);

        public CardValue GetHighCard() => Cards.Max((card) => card.Value);
    };

    public enum HandRank
    {
        NoRank,
        HighCard,
        Pair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}