using System;
using Miniclip.Core.Interfaces;
using Action = System.Action;

namespace Miniclip.Common.Scoring
{
    public class GameScoreService : IScoreService
    {
        private readonly IScoreLoader _scoreLoader;
        private readonly IScoreSaver _scoreSaver;

        public GameScoreService(IScoreLoader scoreLoader, IScoreSaver scoreSaver)
        {
            _scoreLoader = scoreLoader;
            _scoreSaver = scoreSaver;
        }

        public IScoreHandle StartSession()
        {
            var handle = new GameScoreHandle();

            handle.SubmitScoreEvent += SubmitScore;

            return handle;
        }

        public void SubmitScore(IScoreHandle handle)
        {
            handle.SubmitScoreEvent -= SubmitScore;

            _scoreSaver.SaveScore(handle.PlayerName, handle.Score);
        }

        public void FetchScoreData(Action<IScoreData> successCallback, Action failCallback)
        {
            _scoreLoader.FetchScoreData(successCallback, failCallback);
        }
    }
}