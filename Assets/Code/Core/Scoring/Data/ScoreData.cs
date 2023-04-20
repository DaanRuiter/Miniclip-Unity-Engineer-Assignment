using System;
using System.Collections.Generic;

namespace Miniclip.Scoring
{
    [Serializable]
    public class ScoreData
    {
        public List<ScoreDataEntry> Entries;

        public ScoreData()
        {
            Entries = new List<ScoreDataEntry>();
        }
    }
}