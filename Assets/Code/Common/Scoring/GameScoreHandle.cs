using System;
using Miniclip.Core.Interfaces;
using UnityEngine;

namespace Miniclip.Common.Scoring
{
    public class GameScoreHandle : IScoreHandle
    {
        public const int MaxScoreValue = 9999;

        public event Action<int> ScoreUpdatedEvent;

        public event Action<IScoreHandle> SubmitScoreEvent;

        public int Score { get; private set; }

        public string PlayerName { get; private set; }

        public void AdjustScore(int score)
        {
            Score = Mathf.Clamp(Score + score, 0, MaxScoreValue);

            ScoreUpdatedEvent?.Invoke(Score);
        }

        public void SubmitScore(string playerName)
        {
            PlayerName = playerName;

            SubmitScoreEvent?.Invoke(this);
        }
    }
}