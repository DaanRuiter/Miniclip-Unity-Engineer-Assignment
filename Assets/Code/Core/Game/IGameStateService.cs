using Miniclip.Util;

namespace Miniclip.Core
{
    public interface IGameStateService
    {
        ReactiveProperty<GameState> State { get; }

        void SetGameState(GameState gameState);
    }
}