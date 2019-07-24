namespace MoG
{
    public class NumberConversionQuestion : IQuestion
    {
        public NumberConversionQuestion(string galacticNumber)
        {
            GalacticNumber = galacticNumber;
        }

        public string GalacticNumber { get; }

        public IMerchantReply Answer(Merchant merchant)
        {
            var decimalValue = merchant.NumberSystem.GetDecimalValue(GalacticNumber);
            return new NumericConversionReply(GalacticNumber, decimalValue);
        }
    }
}
