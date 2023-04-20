using System;
using Miniclip.Core.Config;
using Miniclip.Scoring;

namespace Miniclip.Core
{
    /// <summary>
    /// An implementation for a game withing this framework
    /// </summary>
    public interface IGame : IPresenter
    {
        /// <summary>
        /// Invoked when the game is finished and should move to the score submission
        /// </summary>
        event Action<GameScoreHandle> GameOverEvent;

        /// <summary>
        /// A collection of all explicit types required for this game's implementation
        /// </summary>
        /// <returns>An instance with every dependency for this game set to the desired instance</returns>
        SystemBindings GetSystemBindings();

        /// <summary>
        /// Initialize the game and setup the scene with prefabs and UI
        /// </summary>
        /// <param name="prefabFactory">Factory that loads and spawns in prefabs for your game, will be the same instance
        /// as provided in the SystemBindings instance</param>
        void Init(IPrefabFactory prefabFactory);

        /// <summary>
        /// Set the config for this game. Contains all configurable gameplay parameters
        /// </summary>
        /// <param name="gameConfig">Final parameters used for the gameplay of this game</param>
        void SetConfig(GameConfig gameConfig);

        /// <summary>
        /// Called when the user presses "start" in the main menu
        /// </summary>
        /// <param name="scoreHandle">An handle used to track and submit the score</param>
        void StartGame(GameScoreHandle scoreHandle);
    }
}