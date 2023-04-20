using System;

namespace Miniclip.Scoring
{
    public interface IScoreLoader
    {
        void FetchScoreData(Action<ScoreData> successCallback, Action failedCallback);
    }
}