using System;
using System.Collections.Generic;
using Xunit;

namespace CsharpPokerFunctional
{
    public class PokerScorer5CardTests
    {
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
            Assert.Equal(CardValue.Eight, hand.Cards.GetHighCard());
        }

        [Fact]
        public void CanScoreHighCard()
        {
            var cards = new HashSet<Card> {
                new Card(CardValue.Two, CardSuit.Hearts),
                new Card(CardValue.Eight, CardSuit.Hearts),
                new Card(CardValue.Four, CardSuit.Diamonds),
                new Card(CardValue.Six, CardSuit.Clubs),
                new Card(CardValue.Three, CardSuit.Hearts),
            };

            var hand = new Hand(cards);
            Assert.Equal(HandRank.HighCard, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.RoyalFlush, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.Flush, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.Pair, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.ThreeOfAKind, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.FourOfAKind, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.TwoPair, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.FullHouse, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.Straight, hand.Cards.GetHandRank());
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

            Assert.Equal(HandRank.StraightFlush, hand.Cards.GetHandRank());
        }
    }
}
