namespace MoG
{
    public class NumericConversionReply : IMerchantReply
    {
        public NumericConversionReply(string galacticNumber, decimal decimalValue)
        {
            GalacticNumber = galacticNumber;
            DecimalValue = decimalValue;
        }

        public string GalacticNumber { get; }

        public decimal DecimalValue { get; }

        public string Text => $"{GalacticNumber} is {DecimalValue}.";
    }
}
