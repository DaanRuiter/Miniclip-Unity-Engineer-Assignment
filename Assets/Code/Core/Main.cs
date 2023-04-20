using Miniclip.Scoring;
using Miniclip.UI.Screens;
using UnityEngine;

namespace Miniclip.Core
{
    /// <summary>
    /// This class represents the main entry point of this game's systems
    /// </summary>
    public static class Main
    {
        private static IGame _game;
        private static MainMenuPresenter _mainMenu;
        private static GameOverPresenter _gameOverScreen;
        private static LeaderboardPresenter _leaderboard;
        private static SystemBindings _systemBindings;

        /// <summary>
        /// Calling this method with the intended game will initialize all systems and start the game flow.
        /// Can also be used from a test case
        /// </summary>
        /// <param name="game">Intended game to initialize</param>
        public static void Init(IGame game, Transform gameContainer, RectTransform uiContainer)
        {
            _systemBindings = game.GetSystemBindings();
            _systemBindings.PrefabFactory.SetDefaultParents(gameContainer, uiContainer);
            _systemBindings.GameStateService.GameStateChangedEvent += OnGameStateSwitched;

            // Spawn main menu
            _mainMenu = _systemBindings.PrefabFactory.SpawnUIPresenter<MainMenuPresenter, MainMenuView>("UI/MainMenu");
            _mainMenu.Init(_systemBindings.GameStateService);

            _gameOverScreen =
                _systemBindings.PrefabFactory.SpawnUIPresenter<GameOverPresenter, GameOverView>("UI/GameOver");
            _gameOverScreen.ScoreSubmittedEvent += OnScoreSubmitted;

            // Spawn leaderboard
            _leaderboard =
                _systemBindings.PrefabFactory.SpawnUIPresenter<LeaderboardPresenter, LeaderboardView>("UI/Leaderboard");
            _leaderboard.Init(_systemBindings.ScoreService);
            _leaderboard.ClosedEvent += OnLeaderboardClosed;

            // Spawn game
            _game = game;
            _game.SetConfig(_systemBindings.GameConfig);
            _game.Init(_systemBindings.PrefabFactory);
            _game.GameOverEvent += OnGameGameOver;
        }

        public static void Start()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Menu);
        }

        public static void Dispose()
        {
            _mainMenu.Destroy();
            _leaderboard.Destroy();
            _game.Destroy();
        }

        private static void OnGameStateSwitched(GameState state)
        {
            _mainMenu.SetVisible(state == GameState.Menu);
            _game.SetVisible(state == GameState.Game);
            _leaderboard.SetVisible(state == GameState.Leaderboard);
            _gameOverScreen.SetVisible(state == GameState.GameOver);
        }

        private static void OnGameGameOver(GameScoreHandle scoreHandle)
        {
            _systemBindings.GameStateService.SetGameState(GameState.GameOver);
            _gameOverScreen.SetScore(scoreHandle);
        }

        private static void OnLeaderboardClosed()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Menu);
        }

        private static void OnScoreSubmitted()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Leaderboard);
        }
    }
}