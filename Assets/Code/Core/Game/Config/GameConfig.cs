namespace Miniclip.Core.Config
{
    public abstract class GameConfig
    {
        public float SecondsPerRound = 20;

        public string MainMenuPrefabPath = "UI/Screens/MainMenu";
        public string LeaderboardPrefabPath = "UI/Screens/Leaderboard";
        public string GameOverPrefabPath = "UI/Screens/GameOver";
    }
}