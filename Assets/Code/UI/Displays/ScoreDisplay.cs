using TMPro;
using UnityEngine;

namespace Miniclip.UI.Displays
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreAmountText;

        public void SetScore(int score)
        {
            _scoreAmountText.SetText(score.ToString());
        }
    }
}