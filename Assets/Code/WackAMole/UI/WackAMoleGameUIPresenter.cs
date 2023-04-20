﻿using Miniclip.UI;
using UnityEngine;

namespace Miniclip.WackAMole.UI
{
    public class WackAMoleGameUIPresenter : UIPresenter<WackAMoleGameUIView>
    {
        public void Reset(float roundTimeSeconds)
        {
            View.SetScore(0);
            View.SetTime(roundTimeSeconds);
        }

        public void SetScore(int score)
        {
            View.SetScore(score);
        }

        public void SetTimeLeft(float timeLeft)
        {
            float time = Mathf.Clamp(timeLeft, 0f, float.MaxValue);

            View.SetTime(time);
        }

        public void SpawnFloatingScoreDisplay(Vector2 screenPosition, int score)
        {
            var floatScore = PrefabFactory.SpawnPrefab<FloatingScoreDisplay>("UI/FloatingScore", View.FloatingScoreContainer);
            floatScore.SetScore(score);
            floatScore.SetScreenPosition(screenPosition);
        }

        protected override void OnViewSet()
        {
        }

        protected override void OnViewUnSet()
        {
        }
    }
}