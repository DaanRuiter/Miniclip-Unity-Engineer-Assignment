using Miniclip.UI;
using UnityEngine;

namespace Miniclip.Core
{
    public interface IPrefabFactory
    {
        void SetDefaultParents(Transform defaultPrefabParent, RectTransform defaultUIParent);

        T SpawnPrefab<T>(string prefabPath, Transform parent = null) where T : Component;

        TPresenter SpawnUIPresenter<TPresenter, TView>(string prefabPath, RectTransform parent = null)
            where TPresenter : UIPresenter<TView>, new()
            where TView : UIView;
    }
}