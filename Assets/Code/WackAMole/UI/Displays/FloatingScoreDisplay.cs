using System.Collections;
using TMPro;
using UnityEngine;

namespace Miniclip.WackAMole.UI
{
    public class FloatingScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private Color _scoreGainColor = Color.green;
        [SerializeField] private Color _scoreLossColor = Color.red;
        [SerializeField] private float _displayDurationSeconds = 0.75f;

        public void SetScreenPosition(Vector2 screenPosition)
        {
            transform.localPosition = screenPosition;
        }

        public void SetScore(int score)
        {
            bool scoreLoss = score < 0;
            string label = scoreLoss ? score.ToString() : $"+{score}";

            _scoreText.color = scoreLoss ? _scoreLossColor : _scoreGainColor;
            _scoreText.text = label;

            StartCoroutine(DestroyDelayed(_displayDurationSeconds));
        }

        private IEnumerator DestroyDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);

            Destroy(gameObject);
        }
    }
}