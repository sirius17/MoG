namespace MoG
{
    public class Merchant
    {
        public PriceList Prices { get; } = new PriceList();

        public GalacticNumberSystem NumberSystem { get; } = new GalacticNumberSystem();

        public Language Language { get; } = new Language();

        public void Tell(string text)
        {
            if (Language.TryParse(text, out ISentence sentence) == false)
                return;
            if (sentence is IStatement stmt)
                stmt.Train(this);
            // Ignore if this is not a valid statement.
            
        }

        public IMerchantReply Ask(string text)
        {
            Language.TryParse(text, out ISentence sentence);
            if (sentence is IQuestion question)
                return question.Answer(this);
            else 
                return new NoIdeaReply();
        }
    }
}
