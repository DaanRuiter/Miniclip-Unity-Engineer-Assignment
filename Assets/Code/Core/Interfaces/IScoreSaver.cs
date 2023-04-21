namespace Miniclip.Core.Interfaces
{
    /// <summary>
    /// Interface for type that can save scores.
    /// These scores can be saved to storage or send to a remote endpoint.
    /// </summary>
    public interface IScoreSaver
    {
        /// <summary>
        /// Saves a single score entry.
        /// The current scores should be loaded first and the new score be added to make sure no data is overwritten.
        /// </summary>
        /// <param name="playerName">Name of player that achieved score</param>
        /// <param name="score">Achieved score by the player</param>
        void SaveScore(string playerName, int score);
    }
}