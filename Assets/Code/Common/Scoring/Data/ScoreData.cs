using System;
using System.Collections.Generic;
using Miniclip.Core.Interfaces;

namespace Miniclip.Common.Scoring
{
    [Serializable]
    public class ScoreData : IScoreData
    {
        public IEnumerable<IScoreDataEntry> ScoreEntries => Entries;

        public List<ScoreDataEntry> Entries;

        public ScoreData()
        {
            Entries = new List<ScoreDataEntry>();
        }

        public void AddScore(IScoreDataEntry entry)
        {
            if (entry is ScoreDataEntry scoreDataEntry)
            {
                Entries.Add(scoreDataEntry);
                return;
            }

            Entries.Add(new ScoreDataEntry
            {
                Score = entry.PlayerScore,
                Name = entry.PlayerName
            });
        }
    }
}