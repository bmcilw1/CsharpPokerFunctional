namespace CsharpPokerFunctional
{
    public record Card(CardValue Value, CardSuit Suit)
    {
        public override string ToString() => $"{Value} of {Suit}";
    };
}