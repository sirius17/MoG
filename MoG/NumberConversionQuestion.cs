namespace MoG
{
    public class NumberConversionQuestion : IQuestion
    {
        public NumberConversionQuestion(string galacticNumber)
        {
            GalacticNumber = galacticNumber;
        }

        public string GalacticNumber { get; }
    }
}
