using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace CsharpPokerFunctional
{
    public class Hand : ValueObject
    {
        public HashSet<Card> Cards { get; init; }

        public Hand(HashSet<Card> cards)
        {
            if (cards.Count != 5)
                throw new ArgumentException("A hand must contain 5 cards");

            Cards = cards;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (Card card in Cards)
                yield return card;
        }

        public HandRank GetHandRank() =>
            ContainsRoyalFlush() ? HandRank.RoyalFlush :
            ContainsFlush() && ContainsStraight() ? HandRank.StraightFlush :
            ContainsFlush() ? HandRank.Flush :
            ContainsFullHouse() ? HandRank.FullHouse :
            ContainsStraight() ? HandRank.Straight :
            HasKOfNCardsOfAKind(1, 4) ? HandRank.FourOfAKind :
            HasKOfNCardsOfAKind(1, 3) ? HandRank.ThreeOfAKind :
            HasKOfNCardsOfAKind(2, 2) ? HandRank.TwoPair :
            HasKOfNCardsOfAKind(1, 2) ? HandRank.Pair :
            HandRank.HighCard;

        private bool ContainsStraight() => Cards.OrderBy(c => c.Value)
            .SelectConsecutive((c1, c2) => c1.Value + 1 == c2.Value)
            .All(c => c);

        private bool HasKOfNCardsOfAKind(int k, int n) =>
            Cards.GroupBy(c => c.Value)
                .Count(g => g.Count() == n) == k;

        private bool ContainsRoyalFlush() =>
            ContainsFlush() && Cards.All(c => c.Value > CardValue.Nine);

        private bool ContainsFullHouse() => HasKOfNCardsOfAKind(1, 3) && HasKOfNCardsOfAKind(1, 2);

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