using System;
using Miniclip.Core.Interfaces;
using UnityEngine;

namespace Miniclip.Common.Scoring
{
    public class PlayerPrefScoreLoader : IScoreLoader
    {
        public void FetchScoreData(Action<IScoreData> successCallback, Action failedCallback)
        {
            string json = PlayerPrefs.HasKey("HighScores") ? PlayerPrefs.GetString("HighScores") : string.Empty;
            ScoreData scoreData;

            try
            {
                scoreData = JsonUtility.FromJson<ScoreData>(json);
            }
            catch (Exception)
            {
                failedCallback?.Invoke();
                throw;
            }

            successCallback?.Invoke(scoreData ?? new ScoreData());
        }
    }
}