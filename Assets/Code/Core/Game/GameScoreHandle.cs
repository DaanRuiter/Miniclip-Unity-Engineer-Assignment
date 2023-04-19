using System;

namespace Miniclip.Core
{
    public class GameScoreHandle
    {
        public event Action<int> ScoreUpdatedEvent;
        public event Action<GameScoreHandle> SubmitScoreEvent;

        public int Score { get; private set; }
        public string PlayerName { get; private set; }

        public void AddScore(int score)
        {
            Score += score;

            ScoreUpdatedEvent?.Invoke(Score);
        }

        public void SubmitScore(string playerName)
        {
            PlayerName = playerName;

            SubmitScoreEvent?.Invoke(this);
        }
    }
}