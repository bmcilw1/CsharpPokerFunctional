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
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Nine, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Spades),
                    new Card(CardValue.King, CardSuit.Spades),
                }
            );

            Assert.True(hand.Cards.Count == 5);
        }

        [Fact]
        public void NoDuplicateCards()
        {
            var cardsDup = new HashSet<Card> {
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Ten, CardSuit.Spades),
                new Card(CardValue.Jack, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.King, CardSuit.Spades),
            };
            var cardsNoDup = new HashSet<Card> {
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Ten, CardSuit.Spades),
                new Card(CardValue.Jack, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.King, CardSuit.Spades),
            };

            var hand = new Hand(cardsDup);
            var handNoDup = new Hand(cardsNoDup);
            Assert.Equal(handNoDup.Cards, hand.Cards);
        }

        [Fact]
        public void DifferentHandsNotEqual()
        {
            var cards1 = new HashSet<Card> {
                new Card(CardValue.Nine, CardSuit.Spades),
                new Card(CardValue.Ten, CardSuit.Spades),
                new Card(CardValue.Jack, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.King, CardSuit.Spades),
            };
            var cards2 = new HashSet<Card> {
                new Card(CardValue.Three, CardSuit.Spades),
                new Card(CardValue.Ten, CardSuit.Spades),
                new Card(CardValue.Jack, CardSuit.Spades),
                new Card(CardValue.Two, CardSuit.Spades),
                new Card(CardValue.King, CardSuit.Spades),
            };

            Assert.NotEqual(new Hand(cards1), new Hand(cards2));
        }

        [Fact]
        public void EmptyHandThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Hand(new HashSet<Card>()));
        }
    }
}
