using System;
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

        [Fact]
        public void SameHandsAreEqual()
        {
            var cards1 = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
            };
            var cards2 = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Hearts),
            };

            Assert.Equal(new Hand(cards1), new Hand(cards2));
        }

        [Fact]
        public void DifferentHandsNotEqual()
        {
            var cards1 = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Spades),
            };
            var cards2 = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
            };

            Assert.NotEqual(new Hand(cards1), new Hand(cards2));
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
        public void EmptyHandNoRank()
        {
            var hand = new Hand(new HashSet<Card>());
            Assert.Equal(HandRank.NoRank, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreHighCard()
        {
            var hand = new Hand(
                new HashSet<Card> {
                    new Card(CardValue.Seven, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Clubs),
                    new Card(CardValue.Five, CardSuit.Hearts),
                    new Card(CardValue.King, CardSuit.Hearts),
                    new Card(CardValue.Two, CardSuit.Hearts)
                }
            );

            Assert.Equal(HandRank.HighCard, hand.GetHandRank());
        }
    }
}
