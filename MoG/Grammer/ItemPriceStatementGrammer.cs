using System;
using System.Linq;

namespace MoG
{
    public class ItemPriceStatementGrammer : IGrammer
    {
        public bool TryParse(string text, out ISentence stmt)
        {
            // text must be of the form "glob glob Silver is 34 Credits".
            // Last token should be credits
            // Second last should be a number
            // Third last token should be is
            // Token before the last 3 tokens is the item name.
            // Everything else is the quantity
            stmt = null;
            if (text.EndsWith("Credits", StringComparison.Ordinal) == false)
                return false;
            var tokens = text.Split(' ');
            if (tokens.Length < 5)
                return false;
            var creditStr = tokens[tokens.Length - 2];
            if (int.TryParse(creditStr, out int valueInCredits) == false)
                return false;
            if (tokens[tokens.Length - 3] != "is")
                return false;
            var itemName = tokens[tokens.Length - 4];
            var quantity = string.Join(" ", tokens.Take(tokens.Length - 4));

            stmt = new ItemPriceStatement(quantity, itemName, valueInCredits);
            return true;
        }
    }



}
