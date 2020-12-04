using Xunit;

namespace CsharpPokerFunctional
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Diamonds);
            Assert.NotNull(card);
        }

        [Fact]
        public void CanCreateCardWithValue()
        {
            var card = new Card(CardValue.Ace, CardSuit.Clubs);

            Assert.Equal(CardValue.Ace, card.Value);
            Assert.Equal(CardSuit.Clubs, card.Suit);
        }

        [Fact]
        public void CanDescribeCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);

            Assert.Equal("Ace of Spades", card.ToString());
        }

        [Fact]
        public void SameAreEqual()
        {
            var card1 = new Card(CardValue.Ace, CardSuit.Spades);
            var card2 = new Card(CardValue.Ace, CardSuit.Spades);

            Assert.Equal(card1, card2);
        }

        [Fact]
        public void DifferentAreNotEqual()
        {
            var card1 = new Card(CardValue.Queen, CardSuit.Spades);
            var card2 = new Card(CardValue.Ace, CardSuit.Spades);

            Assert.NotEqual(card1, card2);
        }
    }
}
