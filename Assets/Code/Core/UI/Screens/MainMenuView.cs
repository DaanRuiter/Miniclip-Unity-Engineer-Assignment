using System;
using UnityEngine;
using UnityEngine.UI;

namespace Miniclip.Core.UI.Screens
{
    public class MainMenuView : UIView
    {
        public event Action StartButtonPressedEvent;

        public event Action LeaderboardButtonPressedEvent;

        public event Action ConfigButtonPressedEvent;

        [SerializeField] private Button _startButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] private Button _configButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnStartButtonPressed);
            _leaderboardButton.onClick.AddListener(OnLeaderboardButtonPressed);

            // _configButton.onClick.AddListener(OnConfigButtonPressed);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(OnStartButtonPressed);
            _leaderboardButton.onClick.RemoveListener(OnLeaderboardButtonPressed);

            // _configButton.onClick.RemoveListener(OnConfigButtonPressed);
        }

        private void OnStartButtonPressed()
        {
            StartButtonPressedEvent?.Invoke();
        }

        private void OnLeaderboardButtonPressed()
        {
            LeaderboardButtonPressedEvent?.Invoke();
        }

        // private void OnConfigButtonPressed()
        // {
        //     ConfigButtonPressedEvent?.Invoke();
        // }
    }
}