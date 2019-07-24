using System;

namespace MoG
{
    public class NumberAliasStatementGrammer : IGrammer
    {
        public bool TryParse(string text, out ISentence stmt)
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
    }



}
