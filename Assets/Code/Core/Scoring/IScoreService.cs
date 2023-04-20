using System;

namespace Miniclip.Scoring
{
    public interface IScoreService
    {
        GameScoreHandle StartSession();

        void SubmitScore(GameScoreHandle handle);

        void FetchScoreData(Action<ScoreData> successCallback, Action failCallback);
    }
}