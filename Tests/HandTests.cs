using System.Collections.Generic;
using Xunit;

namespace CsharpPokerFunctional
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand(new List<Card>());
            Assert.NotNull(hand);
        }

        [Fact]
        public void CanGetHighCard()
        {
            var cards = new List<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Diamonds),
            };

            var hand = new Hand(cards);
            Assert.Equal(CardValue.Eight, hand.GetHighCard());
        }
    }
}
