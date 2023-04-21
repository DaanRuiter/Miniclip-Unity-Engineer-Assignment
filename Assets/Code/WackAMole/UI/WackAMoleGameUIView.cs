using Miniclip.Common.UI.Displays;
using Miniclip.Core.UI;
using UnityEngine;

namespace Miniclip.WackAMole.UI
{
    public class WackAMoleGameUIView : UIView
    {
        [SerializeField] private ScoreDisplay _scoreDisplay;
        [SerializeField] private TimerDisplay _timerDisplay;
        [SerializeField] private RectTransform _floatingScoreContainer;

        public RectTransform FloatingScoreContainer => _floatingScoreContainer;

        public void SetScore(int score)
        {
            _scoreDisplay.SetScore(score);
        }

        public void SetTime(float timeInSeconds)
        {
            _timerDisplay.SetTime(timeInSeconds);
        }
    }
}