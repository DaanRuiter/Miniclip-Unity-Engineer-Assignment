using System;
using UnityEngine;

namespace Miniclip.Scoring
{
    public class GameScoreHandle
    {
        public const int MaxScoreValue = 9999;

        public event Action<int> ScoreUpdatedEvent;

        public event Action<GameScoreHandle> SubmitScoreEvent;

        public int Score { get; private set; }

        public string PlayerName { get; private set; }

        public void AddScore(int score)
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