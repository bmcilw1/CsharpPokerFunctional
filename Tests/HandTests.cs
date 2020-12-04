using System.Collections.Generic;
using Xunit;

namespace CsharpPokerFunctional
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand(new HashSet<Card>());
            Assert.True(hand.Cards.Count == 0);
        }

        [Fact]
        public void CanGetHighCard()
        {
            var cards = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Diamonds),
            };

            var hand = new Hand(cards);
            Assert.Equal(CardValue.Eight, hand.GetHighCard());
        }

        [Fact]
        public void NoDuplicateCards()
        {
            var cardsDup = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Two, CardSuit.Hearts),
            };
            var cardsNoDup = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
            };

            var hand = new Hand(cardsDup);
            Assert.Equal(cardsNoDup, hand.Cards);
        }
    }
}
