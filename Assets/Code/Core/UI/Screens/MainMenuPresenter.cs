using Miniclip.Core.Interfaces;

namespace Miniclip.Core.UI.Screens
{
    public class MainMenuPresenter : UIPresenter<MainMenuView>
    {
        private IGameStateService _gameStateService;

        public void Init(IGameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _gameStateService.GameStateChangedEvent += OnGameStateChanged;
        }

        protected override void OnViewSet()
        {
            View.StartButtonPressedEvent += OnStartButtonPressed;
            View.LeaderboardButtonPressedEvent += OnLeaderboardButtonPressed;
        }

        protected override void OnViewUnSet()
        {
            View.StartButtonPressedEvent -= OnStartButtonPressed;
            View.LeaderboardButtonPressedEvent -= OnLeaderboardButtonPressed;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Menu)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        private void OnStartButtonPressed()
        {
            _gameStateService.SetGameState(GameState.Game);
        }

        private void OnLeaderboardButtonPressed()
        {
            _gameStateService.SetGameState(GameState.Leaderboard);
        }
    }
}