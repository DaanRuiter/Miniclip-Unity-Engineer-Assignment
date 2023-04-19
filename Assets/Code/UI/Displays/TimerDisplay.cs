using TMPro;
using UnityEngine;

namespace Miniclip.UI.Displays
{
    public class TimerDisplay : MonoBehaviour
    {
        private const string TimerFormat = "{0:0.00}";

        [SerializeField] private TextMeshProUGUI _timeRemainingText;

        public void SetTime(float timeInSeconds)
        {
            string timeDisplayText = string.Format(TimerFormat, timeInSeconds);

            _timeRemainingText.SetText(timeDisplayText);
        }
    }
}