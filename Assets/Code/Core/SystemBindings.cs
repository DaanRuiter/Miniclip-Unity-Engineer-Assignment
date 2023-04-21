using Miniclip.Core.Config;
using Miniclip.Core.Interfaces;

namespace Miniclip.Core
{
    public class SystemBindings
    {
        public IGameStateService GameStateService { get; }

        public IScoreService ScoreService { get; }

        public IPrefabFactory PrefabFactory { get; }

        public GameConfig GameConfig { get; }

        public SystemBindings(IGameStateService gameStateService,
            IScoreService scoreService,
            IPrefabFactory prefabFactory,
            GameConfig gameConfig)
        {
            GameStateService = gameStateService;
            ScoreService = scoreService;
            PrefabFactory = prefabFactory;
            GameConfig = gameConfig;
        }
    }
}