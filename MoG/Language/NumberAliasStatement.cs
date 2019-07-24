namespace MoG
{
    public class NumberAliasStatement : IStatement
    {
        public NumberAliasStatement(RomanDigit digit, string alias)
        {
            Digit = digit;
            Alias = alias;
        }

        public RomanDigit Digit { get; }

        public string Alias { get; }

        public void Train(Merchant merchant)
        {
            merchant.NumberSystem.SetAlias(Digit, Alias);
        }
    }
}
