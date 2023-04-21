using System;
using Miniclip.Core.Interfaces;
using Object = UnityEngine.Object;

namespace Miniclip.Core.UI
{
    public abstract class UIPresenter<T> : IPresenter where T : UIView
    {
        public event Action OpenedEvent;

        public event Action ClosedEvent;

        protected IPrefabFactory PrefabFactory;
        protected T View;

        public void SetPrefabFactory(IPrefabFactory prefabFactory)
        {
            PrefabFactory = prefabFactory;
        }

        public void SetView(T view)
        {
            if (View != null)
            {
                OnViewUnSet();
            }

            View = view;

            OnViewSet();
        }

        public void Open()
        {
            if (View.transform.gameObject.activeInHierarchy)
            {
                return;
            }

            View.Open();

            OpenedEvent?.Invoke();
        }

        public void Close()
        {
            if (!View.transform.gameObject.activeInHierarchy)
            {
                return;
            }

            View.Close();

            ClosedEvent?.Invoke();
        }

        public void Destroy()
        {
            if (View != null)
            {
                Object.Destroy(View.gameObject);
            }
        }

        public void SetVisible(bool visible)
        {
            if (visible)
            {
                Open();
            }
            else
            {
                Close();
            }
        }

        protected abstract void OnViewSet();

        protected abstract void OnViewUnSet();
    }
}