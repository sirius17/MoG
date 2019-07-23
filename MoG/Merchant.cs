using System;

namespace MoG
{
    public class Merchant
    {
        public PriceList Prices { get; } = new PriceList();

        public GalacticNumberSystem NumberSystem { get; } = new GalacticNumberSystem();

        public Language Language { get; } = new Language();

        public void Tell(string text)
        {
            Language.TryParseNumberAliasStatement(text, out NumberAliasStatement stmt);
            NumberSystem.SetAlias(stmt.Digit, stmt.Alias);
        }


    }

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
    }

    public interface ISentence
    {
    }

    public interface IStatement : ISentence 
    { 
    }

    public interface IQuestion : ISentence
    {
    }

    public class NumberAliasStatement : IStatement
    {
        public NumberAliasStatement(RomanDigit digit, string alias)
        {
            Digit = digit;
            Alias = alias;
        }

        public RomanDigit Digit { get; }

        public string Alias { get; }
    }
}
