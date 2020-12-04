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
            return HandRank.NoRank;
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