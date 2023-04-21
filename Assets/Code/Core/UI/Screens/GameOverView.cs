using System;
using Miniclip.Core.UI.Elements;
using TMPro;
using UnityEngine;

namespace Miniclip.Core.UI.Screens
{
    public class GameOverView : UIView
    {
        public event Action<string> NameSubmitEvent;

        [SerializeField] private InputDisplay _nameInput;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetPlayerScore(int score)
        {
            _scoreText.SetText(score.ToString());
        }

        private void Awake()
        {
            _nameInput.SubmitEvent += OnPlayerNameSubmitted;
        }

        private void OnDestroy()
        {
            _nameInput.SubmitEvent -= OnPlayerNameSubmitted;
        }

        private void OnPlayerNameSubmitted(string player)
        {
            NameSubmitEvent?.Invoke(player);
        }
    }
}