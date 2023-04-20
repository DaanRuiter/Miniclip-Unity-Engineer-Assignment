using Miniclip.Core;
using Unity.Plastic.Antlr3.Runtime.Misc;
using UnityEngine;

namespace Miniclip.UI
{
    public abstract class UIPresenter<T> : IPresenter where T : UIView
    {
        public event Action OpenedEvent;

        public event Action ClosedEvent;

        protected PrefabFactory PrefabFactory;
        protected T View;

        public void SetPrefabFactory(PrefabFactory prefabFactory)
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
            View.Open();

            OpenedEvent?.Invoke();
        }

        public void Close()
        {
            View.Close();

            ClosedEvent?.Invoke();
        }

        public void Destroy()
        {
            Object.Destroy(View.gameObject);
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