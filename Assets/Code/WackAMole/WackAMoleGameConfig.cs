using Miniclip.Core.Config;

namespace Miniclip.WackAMole
{
    public class WackAMoleGameConfig : GameConfig
    {
        public int MaxHolesPerRow = 3;
        public int MoleHoleCount = 9;
        public int ScoreGainPerMoleHit = 2;
        public int ScoreLossPerEmptyHoleHit = 1;

        public float MinMoleShowDurationSeconds = 0.45f;
        public float MaxMoleShowDurationSeconds = 1f;
        public float MinMoleShowIntervalSeconds = 0.15f;
        public float MaxMoleShowIntervalSeconds = 0.75f;
        public int MinMoleShowCount = 1;
        public int MaxMoleShowCount = 3;
    }
}