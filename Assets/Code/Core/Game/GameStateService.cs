using Miniclip.Util;

namespace Miniclip.Core
{
    public class GameStateService
    {
        public readonly ReactiveProperty<GameState> State;

        private readonly IGame _game;
        private readonly GameScoreService _gameScoreService;

        public GameStateService(IGame game, GameScoreService gameScoreService)
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