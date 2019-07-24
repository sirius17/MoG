namespace MoG
{
    public class ItemPriceQuoteQuestion : IQuestion
    {
        public ItemPriceQuoteQuestion(string galacticQuantity, string itemName)
        {
            GalacticQuantity = galacticQuantity;
            ItemName = itemName;
        }

        public string GalacticQuantity { get; }

        public string ItemName { get; }

        public IMerchantReply Answer(Merchant merchant)
        {
            var quantityInDecimal = merchant.NumberSystem.GetDecimalValue(GalacticQuantity);
            var unitPrice = merchant.Prices.GetUnitPrice(ItemName);
            return new ItemPriceReply(GalacticQuantity, ItemName, unitPrice * quantityInDecimal);
        }
    }
}
