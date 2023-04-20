using System;

namespace Miniclip.Scoring
{
    /// <summary>
    /// Interface for type that can fetch or load scores.
    /// These scores can be loaded from storage or from an endpoint or API.
    /// </summary>
    public interface IScoreLoader
    {
        /// <summary>
        /// Fetch the current high scores as last saved
        /// </summary>
        /// <param name="successCallback">Callback with the loaded scores</param>
        /// <param name="failedCallback">Callback for when something went wrong during the scores being loading</param>
        void FetchScoreData(Action<ScoreData> successCallback, Action failedCallback);
    }
}