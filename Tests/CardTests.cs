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
    }
}
