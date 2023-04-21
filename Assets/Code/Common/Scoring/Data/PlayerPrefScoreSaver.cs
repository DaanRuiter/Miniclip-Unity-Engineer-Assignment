using Miniclip.Core.Interfaces;
using UnityEngine;

namespace Miniclip.Common.Scoring
{
    public class PlayerPrefScoreSaver : IScoreSaver
    {
        private IScoreLoader _scoreLoader;

        public PlayerPrefScoreSaver(IScoreLoader scoreLoader)
        {
            _scoreLoader = scoreLoader;
        }

        public void SaveScore(string playerName, int score)
        {
            _scoreLoader.FetchScoreData(scoreData =>
                {
                    scoreData.AddScore(new ScoreDataEntry
                    {
                        Name = playerName,
                        Score = score
                    });

                    string json = JsonUtility.ToJson(scoreData);
                    PlayerPrefs.SetString("HighScores", json);
                    PlayerPrefs.Save();
                },
                () => Debug.LogError($"Something went wrong trying to fetch the scores"));
        }
    }
}