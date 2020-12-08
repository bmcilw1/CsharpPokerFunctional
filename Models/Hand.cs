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
            ContainsFlush() ? HandRank.Flush :
            ContainsFullHouse() ? HandRank.FullHouse :
            NumberDuplicateCardsByValue() == 4 ? HandRank.FourOfAKind :
            NumberDuplicateCardsByValue() == 3 ? HandRank.ThreeOfAKind :
            NumberDuplicateCardsByValue() == 2 ? HandRank.Pair :
            HandRank.HighCard;

        private IEnumerable<DuplicateCard> GetDuplicateCardsByValue() =>
            Cards.GroupBy(c => c.Value, c => new DuplicateCard { Value = c.Value })
                .Where(g => g.Count() > 1)
                .Select(g => new DuplicateCard { Value = g.Key, DuplicateCount = g.Count() })
                .OrderByDescending(c => c.DuplicateCount);

        private int NumberDuplicateCardsByValue() =>
            GetDuplicateCardsByValue()
                .FirstOrDefault()?.DuplicateCount ?? 0;

        private bool IsFullHand() => Cards.Count == 5;

        private bool ContainsRoyalFlush() =>
            ContainsFlush() && Cards.All(c => c.Value > CardValue.Nine);

        private bool ContainsFullHouse()
        {
            var duplicates = GetDuplicateCardsByValue();
            return duplicates.Count() > 1 &&
                duplicates.ElementAtOrDefault(0)?.DuplicateCount == 3 &&
                duplicates.ElementAtOrDefault(1)?.DuplicateCount == 2;
        }

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

    record DuplicateCard
    {
        public CardValue Value;
        public int DuplicateCount;
    }
}