using Miniclip.Core;

namespace Miniclip.UI.Screens
{
    public class MainMenuPresenter : UIPresenter<MainMenuView>
    {
        private GameStateService _gameStateService;

        public void Init(GameStateService gameStateService)
        {
            _gameStateService = gameStateService;
            _gameStateService.State.ValueUpdatedEvent += OnGameStateChanged;
        }

        protected override void OnViewSet()
        {
            View.StartButtonPressedEvent += OnStartButtonPressed;
            View.LeaderboardButtonPressedEvent += OnLeaderboardButtonPressed;
            View.ConfigButtonPressedEvent += OnConfigButtonPressed;
        }

        protected override void OnViewUnSet()
        {
            View.StartButtonPressedEvent -= OnStartButtonPressed;
            View.LeaderboardButtonPressedEvent -= OnLeaderboardButtonPressed;
            View.ConfigButtonPressedEvent -= OnConfigButtonPressed;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Menu)
            {
                Show();
            }
            else
            {
                Hide();
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

        private void OnConfigButtonPressed()
        {
            _gameStateService.SetGameState(GameState.Config);
        }
    }
}