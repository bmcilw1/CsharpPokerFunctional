using System;
using System.Collections.Generic;
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
    };

    public enum HandRank
    {
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