public record Card(CardValue Value, CardSuit Suit)
{
    public override string ToString() => $"{Value} of {Suit}";
};

public enum CardValue
{
    Two = 2,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public enum CardSuit
{
    Spades,
    Diamonds,
    Clubs,
    Hearts
}