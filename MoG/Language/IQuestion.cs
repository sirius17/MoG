namespace MoG
{
    public interface IQuestion : ISentence
    {
        IMerchantReply Answer(Merchant merchant);
    }
}
