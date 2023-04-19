using Miniclip.Core.Config;

namespace Miniclip.WackAMole
{
    public class WackAMoleGameConfig : GameConfig
    {
        public int MaxHolesPerRow = 3;
        public int MoleHoleCount = 9;
        public int ScoreGainPerMoleHit = 2;
        public int ScoreLossPerEmptyHoleHit = 1;

        public float MinMoleShowDurationSeconds = 0.75f;
        public float MaxMoleShowDurationSeconds = 1.5f;
        public float MinMoleShowIntervalSeconds = 0.35f;
        public float MaxMoleShowIntervalSeconds = 1.5f;
    }
}