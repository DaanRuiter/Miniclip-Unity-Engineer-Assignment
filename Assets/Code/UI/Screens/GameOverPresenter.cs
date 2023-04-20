using Miniclip.Scoring;

namespace Miniclip.UI.Screens
{
    public class GameOverPresenter : UIPresenter<GameOverView>
    {
        private GameScoreHandle _scoreHandle;

        public void Init(GameScoreHandle scoreHandle)
        {
            _scoreHandle = scoreHandle;
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
        }
    }
}