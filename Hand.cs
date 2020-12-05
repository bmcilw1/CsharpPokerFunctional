using System;
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
            {
                yield return card;
            }
        }

        public HandRank GetHandRank() =>
            !IsFullHand() ? HandRank.NoRank :
            ContainsRoyalFlush() ? HandRank.RoyalFlush :
            ContainsFlush() ? HandRank.Flush :
            HandRank.HighCard;

        private bool IsFullHand() => Cards.Count == 5;

        private bool ContainsRoyalFlush() =>
            ContainsFlush() && Cards.All(c => c.Value > CardValue.Nine);

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