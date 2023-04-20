using System;

namespace Miniclip.Scoring
{
    [Serializable]
    public class ScoreData
    {
        public string GameName;
        public ScoreDataEntry[] Entries;
    }
}