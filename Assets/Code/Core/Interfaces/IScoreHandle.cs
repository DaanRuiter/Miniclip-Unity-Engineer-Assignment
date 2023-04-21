using System;

namespace Miniclip.Core.Interfaces
{
    public interface IScoreHandle
    {
        event Action<int> ScoreUpdatedEvent;

        event Action<IScoreHandle> SubmitScoreEvent;

        int Score { get; }

        string PlayerName { get; }

        void AdjustScore(int score);

        void SubmitScore(string playerName);
    }
}