using System.Collections.Generic;

namespace Miniclip.Core.Interfaces
{
    public interface IScoreData
    {
        IEnumerable<IScoreDataEntry> ScoreEntries { get; }

        void AddScore(IScoreDataEntry entry);
    }
}