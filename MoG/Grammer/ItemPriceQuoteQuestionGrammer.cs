using System;
using System.Linq;

namespace MoG
{
    public class ItemPriceQuoteQuestionGrammer : IGrammer
    {
        public bool TryParse(string text, out ISentence sentence)
        {
            // text must be of the form "how many Credits is glob prok Silver ?".
            // must have atleast 7 tokens
            // Must end in ?
            // Must start with "How many Credits is "
            // Second last token is the item name
            // Rest is the quantity.
            sentence = null;
            if (text.StartsWith("how many Credits is ", StringComparison.Ordinal) == false)
                return false;
            if (text.EndsWith("?", StringComparison.Ordinal) == false)
                return false;
            var tokens = text
                            .Replace("how many Credits is ", string.Empty)
                            .Replace(" ?", string.Empty)
                            .Split(' ');
            var itemName = tokens.Last();
            var quantity = string.Join(" ",tokens.Take(tokens.Length - 1));
            sentence = new ItemPriceQuoteQuestion(quantity, itemName);
            return true;
        }
    }



}
