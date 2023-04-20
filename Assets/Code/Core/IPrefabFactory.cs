using Miniclip.UI;
using UnityEngine;

namespace Miniclip.Core
{
    /// <summary>
    /// Factory for loading and spawning prefabs
    /// </summary>
    public interface IPrefabFactory
    {
        /// <summary>
        /// Set the default parents for spawned prefabs and UI presenters.
        /// Will be used if no parent is provided.
        /// </summary>
        /// <param name="defaultPrefabParent">Default parent for gameplay related prefabs, used in SpawnPrefab()</param>
        /// <param name="defaultUIParent">Default parent for UI views, used in SpawnUIPresenter</param>
        void SetDefaultParents(Transform defaultPrefabParent, RectTransform defaultUIParent);

        /// <summary>
        /// Load and spawn a prefab in the game world.
        /// </summary>
        /// <param name="prefabPath">Path at which the prefab presides.
        /// Should only contain the path after the root prefab folder</param>
        /// <param name="parent">Desired parent of the prefab. If none provided, the default prefab parent is used.</param>
        /// <typeparam name="T">The desired component on this prefab. use Transform if no component is needed. </typeparam>
        /// <returns>A new instance of the prefab or null if the prefab could not be found.</returns>
        T SpawnPrefab<T>(string prefabPath, Transform parent = null) where T : Component;

        /// <summary>
        /// Spawns a new UI presenter and an instance of the view prefab.
        /// </summary>
        /// <param name="prefabPath">Path at which the prefab presides.
        /// Should only contain the path after the root prefab folder.</param>
        /// <param name="parent">Desired parent of the prefab. If none provided, the default UI parent is used.</param>
        /// <typeparam name="TPresenter">Presenter type that accepts the TView type.</typeparam>
        /// <typeparam name="TView">View component that is on the desired UI prefab.</typeparam>
        /// <returns>A new instance of the presenter with a linked view or null if the prefab could not be found.</returns>
        TPresenter SpawnUIPresenter<TPresenter, TView>(string prefabPath, RectTransform parent = null)
            where TPresenter : UIPresenter<TView>, new()
            where TView : UIView;
    }
}