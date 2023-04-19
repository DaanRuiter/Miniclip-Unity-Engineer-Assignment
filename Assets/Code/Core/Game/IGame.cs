using Miniclip.Core.Config;

namespace Miniclip.Core
{
    public interface IGame : IPresenter
    {
        void Init(PrefabFactory prefabFactory);
        void SetConfig(GameConfig gameConfig);
        void StartGame(GameScoreHandle scoreHandle);
    }
}