namespace MoG
{
    public interface IGrammer
    {
        bool TryParse(string text, out ISentence sentence);
    }



}
