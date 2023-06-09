﻿using TMPro;
using UnityEngine;

namespace Miniclip.Core.UI.Elements
{
    public class LeaderboardEntryDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void Init(string playerName, int score)
        {
            _nameText.SetText(playerName);
            _scoreText.SetText(score.ToString());
        }
    }
}