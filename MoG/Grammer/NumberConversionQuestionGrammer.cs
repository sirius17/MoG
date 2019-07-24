using System;

namespace MoG
{
    public class NumberConversionQuestionGrammer : IGrammer
    {
        public bool TryParse(string text, out ISentence stmt)
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
