using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Miniclip.UI.Displays
{
    public class InputDisplay : MonoBehaviour
    {
        public event Action<string> SubmitEvent;

        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _submitButton;

        private void Awake()
        {
            _submitButton.onClick.AddListener(OnSubmitButtonPressed);
        }

        private void OnDestroy()
        {
            _submitButton.onClick.RemoveListener(OnSubmitButtonPressed);
        }

        private void OnSubmitButtonPressed()
        {
            SubmitEvent?.Invoke(_inputField.text);
        }
    }
}