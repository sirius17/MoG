namespace MoG
{
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

        public void Train(Merchant merchant)
        {
            var quantityInDecimal = merchant.NumberSystem.GetDecimalValue(QuantityInGalaticLanguage);
            var unitPrice = ValueInCredits / quantityInDecimal;
            merchant.Prices.AddItem(new Item(ItemName, unitPrice));
        }
    }
}
