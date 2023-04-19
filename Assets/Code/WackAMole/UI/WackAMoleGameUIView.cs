using Miniclip.UI;
using Miniclip.UI.Displays;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Miniclip.WackAMole.UI
{
    public class WackAMoleGameUIView : UIView, IPointerClickHandler
    {
        [SerializeField] private ScoreDisplay _scoreDisplay;
        [SerializeField] private TimerDisplay _timerDisplay;

        public void SetScore(int score)
        {
            _scoreDisplay.SetScore(score);
        }

        public void SetTime(float timeInSeconds)
        {
            _timerDisplay.SetTime(timeInSeconds);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"Click at {eventData.position}");
        }
    }
}