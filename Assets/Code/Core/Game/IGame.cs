using System;
using Miniclip.Core.Config;
using Miniclip.Scoring;

namespace Miniclip.Core
{
    public interface IGame : IPresenter
    {
        event Action<GameScoreHandle> RoundTimerElapsedEvent;

        SystemBindings GetSystemBindings();

        void Init(IPrefabFactory prefabFactory);

        void SetConfig(GameConfig gameConfig);

        void StartGame(GameScoreHandle scoreHandle);
    }
}