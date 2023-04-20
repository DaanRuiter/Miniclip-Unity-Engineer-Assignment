using System;
using UnityEngine;

namespace Miniclip.Scoring
{
    public class PlayerPrefScoreLoader : IScoreLoader
    {
        public void FetchScoreData(Action<ScoreData> successCallback, Action failedCallback)
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