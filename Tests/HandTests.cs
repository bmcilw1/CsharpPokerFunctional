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
        public void CanGetHighCard()
        {
            var cards = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Three, CardSuit.Diamonds),
                new Card(CardValue.Three, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Hearts),
            };

            var hand = new Hand(cards);
            Assert.Equal(CardValue.Eight, hand.GetHighCard());
        }

        [Fact]
        public void EmptyHandThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Hand(new HashSet<Card>()));
        }

        [Fact]
        public void CanScoreRoyalFlush()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Queen, CardSuit.Spades),
                    new Card(CardValue.King, CardSuit.Spades),
                    new Card(CardValue.Ace, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.RoyalFlush, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreFlush()
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

            Assert.Equal(HandRank.Flush, hand.GetHandRank());
        }

        [Fact]
        public void CanScorePair()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Nine, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Hearts),
                    new Card(CardValue.King, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.Pair, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreThreeOfAKind()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Two, CardSuit.Hearts),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Clubs),
                    new Card(CardValue.Three, CardSuit.Hearts),
                    new Card(CardValue.Two, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.ThreeOfAKind, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreFourOfAKind()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Two, CardSuit.Hearts),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Clubs),
                    new Card(CardValue.Two, CardSuit.Diamonds),
                    new Card(CardValue.Two, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.FourOfAKind, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreTwoPairs()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Two, CardSuit.Hearts),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Clubs),
                    new Card(CardValue.Ten, CardSuit.Diamonds),
                    new Card(CardValue.Three, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.TwoPair, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreFullHouse()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.Ten, CardSuit.Hearts),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Clubs),
                    new Card(CardValue.Two, CardSuit.Diamonds),
                    new Card(CardValue.Two, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.FullHouse, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreStraightUnordered()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.King, CardSuit.Hearts),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Clubs),
                    new Card(CardValue.Nine, CardSuit.Diamonds),
                    new Card(CardValue.Queen, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.Straight, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreStraightFlush()
        {
            var hand = new Hand(
                new HashSet<Card>
                {
                    new Card(CardValue.King, CardSuit.Spades),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Nine, CardSuit.Spades),
                    new Card(CardValue.Queen, CardSuit.Spades),
                }
            );

            Assert.Equal(HandRank.StraightFlush, hand.GetHandRank());
        }
    }
}
