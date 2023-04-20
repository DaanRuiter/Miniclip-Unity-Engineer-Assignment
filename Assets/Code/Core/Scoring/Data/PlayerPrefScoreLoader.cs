using System;
using UnityEngine;

namespace Miniclip.Scoring
{
    public class PlayerPrefScoreLoader : IScoreLoader
    {
        private const string Key = "Highscores";

        public void FetchScoreData(Action<ScoreData> successCallback, Action failedCallback)
        {
            string json = PlayerPrefs.HasKey(Key) ? PlayerPrefs.GetString(Key) : string.Empty;
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

            successCallback?.Invoke(scoreData);
        }
    }
}