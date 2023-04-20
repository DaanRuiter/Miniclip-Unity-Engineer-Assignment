using System;
using Miniclip.Scoring;

namespace Miniclip.Core
{
    public class GameStateService : IGameStateService
    {
        public event Action<GameState> GameStateChangedEvent;

        public GameState State { get; private set; }

        private readonly IGame _game;
        private readonly IScoreService _gameScoreService;

        public GameStateService(IGame game, IScoreService gameScoreService)
        {
            _game = game;
            _gameScoreService = gameScoreService;

            State = GameState.None;
            GameStateChangedEvent += OnGameStateChanged;
        }

        public void SetGameState(GameState gameState)
        {
            if (State == gameState)
            {
                return;
            }

            State = gameState;
            GameStateChangedEvent?.Invoke(gameState);
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Game)
            {
                var scoreHandle = _gameScoreService.StartSession();

                _game.StartGame(scoreHandle);
            }
        }
    }
}