namespace MoG
{
    public class ItemPriceReply : IMerchantReply
    {
        public ItemPriceReply(string galacticQuantity, string itemName, float priceInCredits)
        {
            GalacticQuantity = galacticQuantity;
            ItemName = itemName;
            PriceInCredits = priceInCredits;
        }

        public string GalacticQuantity { get; }

        public string ItemName { get; }

        public float PriceInCredits { get; }

        public string Text => $"{GalacticQuantity} {ItemName} is {PriceInCredits} Credits";
    }
}
