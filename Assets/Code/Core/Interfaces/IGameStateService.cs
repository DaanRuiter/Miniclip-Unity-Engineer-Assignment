using System;

namespace Miniclip.Core.Interfaces
{
    /// <summary>
    /// Service responsible for tracking and updating the game's state 
    /// </summary>
    public interface IGameStateService
    {
        /// <summary>
        /// Invoked whenever the game state was changed to a new state
        /// </summary>
        event Action<GameState> GameStateChangedEvent;

        /// <summary>
        /// The current game state
        /// </summary>
        GameState State { get; }

        /// <summary>
        /// Switch to a different game state
        /// If the existing game state is provided, it should do nothing
        /// </summary>
        /// <param name="gameState">The target game state</param>
        void SetGameState(GameState gameState);
    }
}