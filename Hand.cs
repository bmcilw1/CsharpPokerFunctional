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
            Cards = cards;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            foreach (Card card in Cards)
            {
                yield return card;
            }
        }

        public HandRank GetHandRank()
        {
            if (ContainsRoyalFlush())
                return HandRank.RoyalFlush;
            else
                return HandRank.NoRank;
        }

        private bool IsFullHand()
        {
            return Cards.Count == 5;
        }

        private bool ContainsRoyalFlush()
        {
            if (!IsFullHand())
                return false;

            CardSuit suit = Cards.First().Suit;
            foreach (Card card in Cards)
            {
                if (card.Suit != suit || card.Value > CardValue.Ace || card.Value < CardValue.Ten)
                    return false;
            }

            return true;
        }

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