using Miniclip.Scoring;
using Miniclip.Util;

namespace Miniclip.Core
{
    public class GameStateService : IGameStateService
    {
        public ReactiveProperty<GameState> State { get; }

        private readonly IGame _game;
        private readonly IScoreService _gameScoreService;

        public GameStateService(IGame game, IScoreService gameScoreService)
        {
            _game = game;
            _gameScoreService = gameScoreService;

            State = new ReactiveProperty<GameState>(GameState.None);
            State.ValueUpdatedEvent += OnGameStateChanged;
        }

        public void SetGameState(GameState gameState)
        {
            State.SetValue(gameState);
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