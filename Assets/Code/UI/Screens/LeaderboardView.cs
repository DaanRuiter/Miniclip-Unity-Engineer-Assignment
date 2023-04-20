using System;
using UnityEngine;
using UnityEngine.UI;

namespace Miniclip.UI.Screens
{
    public class LeaderboardView : UIView
    {
        public event Action CloseButtonPressedEvent;

        [SerializeField] private Button _closeButton;
        [SerializeField] private RectTransform _entryContainer;

        public RectTransform EntryContainer => _entryContainer;

        public void DisposeEntries()
        {
            foreach (Transform entry in _entryContainer)
            {
                Destroy(entry.gameObject);
            }
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonPressed);
        }

        private void OnCloseButtonPressed()
        {
            CloseButtonPressedEvent?.Invoke();
        }
    }
}