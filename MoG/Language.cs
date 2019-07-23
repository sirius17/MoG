using System;
using System.Linq;

namespace MoG
{
    public class Language
    {
        public bool TryParseNumberAliasStatement(string text, out NumberAliasStatement stmt)
        {
            // text must be of the form "pish is 1".
            // Should have 3 words.
            // Middle should be is
            // Last should be a valid roman digit.
            stmt = null;
            var tokens = text.Split(' ');
            if (tokens.Length != 3)
                return false;
            if (Enum.TryParse<RomanDigit>(tokens[2], out RomanDigit digit) == false)
                return false;
            if (tokens[1] != "is")
                return false;

            stmt = new NumberAliasStatement(digit, tokens[0]);
            return true;
        }


        public bool TryParseItemPriceStatement(string text, out ItemPriceStatement stmt)
        {
            // text must be of the form "pish pish Silver is 34 credits".
            // Last token should be credits
            // Second last should be a number
            // Third last token should be is
            // Token before the last 3 tokens is the item name.
            // Everything else is the quantity
            stmt = null;
            if (text.EndsWith("credits", StringComparison.Ordinal) == false)
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


        public bool TryParseNumberConversionQuestion(string text, out NumberConversionQuestion stmt)
        {
            // text must be of the form "how much is pish glob ?".
            // Should start with how much is
            // Must end in ?
            // Everthing in between is the number
            stmt = null;
            if (text.StartsWith("how much is ", StringComparison.Ordinal) == false)
                return false;
            if (text.EndsWith("?", StringComparison.Ordinal) == false)
                return false;
            var number = text
                            .Replace("how much is ", string.Empty)
                            .Replace(" ?", string.Empty);
            stmt = new NumberConversionQuestion(number);
            return true;
        }
    }
}
