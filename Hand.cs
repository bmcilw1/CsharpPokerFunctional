using System.Collections.Generic;
using System.Linq;


namespace CsharpPokerFunctional
{
    public record Hand(List<Card> Cards)
    {
        public CardValue GetHighCard()
        {
            return Cards
                .OrderBy((card) => card.Value)
                .LastOrDefault()
                .Value;
        }
    };
}