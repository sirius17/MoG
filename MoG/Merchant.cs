namespace MoG
{
    public class Merchant
    {
        public PriceList Prices { get; } = new PriceList();

        public GalacticNumberSystem NumberSystem { get; } = new GalacticNumberSystem();

        public Language Language { get; } = new Language();

        public void Tell(string text)
        {
            if (Language.TryParseNumberAliasStatement(text, out NumberAliasStatement stmt) == true)
            {
                NumberSystem.SetAlias(stmt.Digit, stmt.Alias);
            }
            else if( Language.TryParseItemPriceStatement(text, out ItemPriceStatement stmt2) == true)
            {
                var quantityInDecimal = NumberSystem.GetDecimalValue(stmt2.QuantityInGalaticLanguage);
                var unitPrice = stmt2.ValueInCredits / quantityInDecimal;
                Prices.AddItem(new Item(stmt2.ItemName, unitPrice));
            }
        }

        public IMerchantReply Ask(string text)
        {
            Language.TryParseNumberConversionQuestion(text, out NumberConversionQuestion question);
            var decimalValue = this.NumberSystem.GetDecimalValue(question.GalacticNumber);
            return new NumericConversionReply(question.GalacticNumber, decimalValue);
        }
    }


    public class ItemPriceStatement : IStatement
    {
        public ItemPriceStatement(string quantity, string itemName, int valueInCredits)
        {
            QuantityInGalaticLanguage = quantity;
            ItemName = itemName;
            ValueInCredits = valueInCredits;
        }

        public string QuantityInGalaticLanguage { get; }

        public string ItemName { get; }

        public int ValueInCredits { get; }
    }


}
