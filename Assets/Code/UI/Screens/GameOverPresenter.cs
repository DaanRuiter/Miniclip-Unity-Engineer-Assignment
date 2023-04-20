using System;
using Miniclip.Scoring;

namespace Miniclip.UI.Screens
{
    public class GameOverPresenter : UIPresenter<GameOverView>
    {
        public event Action ScoreSubmittedEvent;

        private GameScoreHandle _scoreHandle;

        public void SetScore(GameScoreHandle scoreHandle)
        {
            _scoreHandle = scoreHandle;

            View.SetPlayerScore(_scoreHandle.Score);
        }

        protected override void OnViewSet()
        {
            View.NameSubmitEvent += OnNameSubmitted;
        }

        protected override void OnViewUnSet()
        {
            View.NameSubmitEvent -= OnNameSubmitted;
        }

        private void OnNameSubmitted(string playerName)
        {
            _scoreHandle.SubmitScore(playerName);

            Close();

            ScoreSubmittedEvent?.Invoke();
        }
    }
}