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

        T SpawnPrefab<T>(string prefabPath, Transform parent = null) where T : Component;

        TPresenter SpawnUIPresenter<TPresenter, TView>(string prefabPath, RectTransform parent = null)
            where TPresenter : UIPresenter<TView>, new()
            where TView : UIView;
    }
}