using Miniclip.Scoring;
using Miniclip.UI.Screens;
using UnityEngine;

namespace Miniclip.Core
{
    /// <summary>
    /// This class represents the main entry point of this game's systems
    /// </summary>
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _gameContainer;
        [SerializeField] private RectTransform _UIContainer;

        private IGame _game;
        private MainMenuPresenter _mainMenu;
        private GameOverPresenter _gameOverScreen;
        private LeaderboardPresenter _leaderboard;
        private SystemBindings _systemBindings;

        private void Awake()
        {
            var currentGame = GetComponent<IGame>();

            if (currentGame != null)
            {
                Init(currentGame);
            }
        }

        private void Start()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Menu);
        }

        private void OnDestroy()
        {
            Dispose();
        }

        /// <summary>
        /// Calling this method with the intended game will initialize all systems and start the game flow.
        /// Can also be used from a test case
        /// </summary>
        /// <param name="game">Intended game to initialize</param>
        private void Init(IGame game)
        {
            _systemBindings = game.GetSystemBindings();
            _systemBindings.PrefabFactory.SetDefaultParents(_gameContainer, _UIContainer);
            _systemBindings.GameStateService.State.ValueUpdatedEvent += OnGameStateSwitched;

            // Spawn main menu
            _mainMenu = _systemBindings.PrefabFactory.SpawnUIPresenter<MainMenuPresenter, MainMenuView>("UI/MainMenu");
            _mainMenu.Init(_systemBindings.GameStateService);

            _gameOverScreen =
                _systemBindings.PrefabFactory.SpawnUIPresenter<GameOverPresenter, GameOverView>("UI/GameOver");
            _gameOverScreen.ScoreSubmittedEvent += OnScoreSubmitted;

            // Spawn leaderboard
            _leaderboard =
                _systemBindings.PrefabFactory.SpawnUIPresenter<LeaderboardPresenter, LeaderboardView>("UI/Leaderboard");
            _leaderboard.Close();
            _leaderboard.ClosedEvent += OnLeaderboardClosed;

            // Spawn game
            _game = game;
            _game.SetConfig(_systemBindings.GameConfig);
            _game.Init(_systemBindings.PrefabFactory);
            _game.RoundTimerElapsedEvent += OnGameRoundTimerElapsed;
        }

        private void Dispose()
        {
            _mainMenu.Destroy();
            _leaderboard.Destroy();
            _game.Destroy();
        }

        private void OnGameStateSwitched(GameState state)
        {
            _mainMenu.SetVisible(state == GameState.Menu);
            _game.SetVisible(state == GameState.Game);
            _leaderboard.SetVisible(state == GameState.Leaderboard);
            _gameOverScreen.SetVisible(state == GameState.GameOver);

            Debug.Log($"Switched game state to {state}");
        }

        private void OnGameRoundTimerElapsed(GameScoreHandle scoreHandle)
        {
            _systemBindings.GameStateService.SetGameState(GameState.GameOver);
            _gameOverScreen.SetScore(scoreHandle);
        }

        private void OnLeaderboardClosed()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Menu);
        }

        private void OnScoreSubmitted()
        {
            _systemBindings.GameStateService.SetGameState(GameState.Leaderboard);
        }
    }
}