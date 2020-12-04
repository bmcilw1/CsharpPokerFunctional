using System.Collections.Generic;
using System.Linq;

namespace CsharpPokerFunctional
{
    public record Hand(HashSet<Card> Cards)
    {
        public CardValue GetHighCard() => Cards.Max((card) => card.Value);
    };
}