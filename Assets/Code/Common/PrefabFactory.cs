using Miniclip.Core.Interfaces;
using Miniclip.Core.UI;
using UnityEngine;

namespace Miniclip.Common
{
    public class PrefabFactory : IPrefabFactory
    {
        private const string BasePrefabPath = "Prefabs/";

        private Transform _defaultPrefabParent;
        private RectTransform _defaultUIParent;

        public void SetDefaultParents(Transform defaultPrefabParent, RectTransform defaultUIParent)
        {
            _defaultPrefabParent = defaultPrefabParent;
            _defaultUIParent = defaultUIParent;
        }

        /// <summary>
        /// Loads the prefab at the specified path and will instantiate it on the provided parent.
        /// If no parent is provided, the default parent will be used instead.
        /// </summary>
        /// <param name="prefabPath">Path at which the prefab exists. Is automatically prefixed with the base folder</param>
        /// <param name="parent"></param>
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

        public TPresenter SpawnUIPresenter<TPresenter, TView>(string prefabPath, RectTransform parent = null)
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