namespace Miniclip.Scoring
{
    public interface IScoreSaver
    {
        void SaveScore(string playerName, int score);
    }
}