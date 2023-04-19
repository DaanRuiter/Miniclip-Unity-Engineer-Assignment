using Miniclip.UI;
using UnityEngine;

namespace Miniclip.Core
{
    public class PrefabFactory
    {
        private const string BasePrefabPath = "Prefabs/";

        private Transform _defaultPrefabParent;
        private RectTransform _defaultUIParent;

        public PrefabFactory(Transform defaultPrefabParent, RectTransform defaultUIParent)
        {
            _defaultPrefabParent = defaultPrefabParent;
            _defaultUIParent = defaultUIParent;
        }

        public T SpawnPrefab<T>(string prefabPath, Transform parent = null) where T : Component
        {
            string path = BasePrefabPath + prefabPath;

            var prefab = Resources.Load<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogError($"Failed to load prefab at {path}");
                return default;
            }

            var component = prefab.GetComponent<T>();
            if (component == null)
            {
                Debug.LogError($"Loaded prefab does not contain component of type {typeof(T)}");
                return default;
            }

            var gameObject = Object.Instantiate(prefab, parent ? parent : _defaultPrefabParent);
            var instance = gameObject.GetComponent<T>();

            return instance;
        }

        public TPresenter SpawnUIPrefab<TPresenter, TView>(string prefabPath, RectTransform parent = null)
            where TPresenter : UIPresenter<TView>, new()
            where TView : UIView
        {
            var view = SpawnPrefab<TView>(prefabPath, parent ? parent : _defaultUIParent);
            if (view == null)
            {
                return null;
            }

            var presenter = new TPresenter();
            presenter.SetPrefabFactory(this);
            presenter.SetView(view);

            return presenter;
        }
    }
}