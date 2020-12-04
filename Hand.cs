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
            if (!IsFullHand())
                return HandRank.NoRank;
            else if (ContainsRoyalFlush())
                return HandRank.RoyalFlush;
            else if (ContainsFlush())
                return HandRank.Flush;
            else
                return HandRank.HighCard;
        }

        private bool IsFullHand()
        {
            return Cards.Count == 5;
        }

        private bool ContainsRoyalFlush()
        {
            CardSuit suit = Cards.First().Suit;
            foreach (Card card in Cards)
            {
                if (card.Suit != suit || card.Value > CardValue.Ace || card.Value < CardValue.Ten)
                    return false;
            }

            return true;
        }

        private bool ContainsFlush()
        {
            List<Card> orderedCards = Cards.ToList().OrderBy((card) => card.Value).ToList();
            for (int i = 1; i < orderedCards.Count; i++)
            {
                if (orderedCards[i - 1].Suit != orderedCards[i].Suit || orderedCards[i - 1].Value + 1 != orderedCards[i].Value)
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