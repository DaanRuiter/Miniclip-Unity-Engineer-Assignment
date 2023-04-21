using System;
using Miniclip.Core.Interfaces;

namespace Miniclip.Common.Scoring
{
    [Serializable]
    public class ScoreDataEntry : IScoreDataEntry
    {
        public string PlayerName => Name;

        public int PlayerScore => Score;

        public string Name;
        public int Score;
    }
}