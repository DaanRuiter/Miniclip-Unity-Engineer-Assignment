using Miniclip.Core;

namespace Miniclip.UI
{
    public abstract class UIPresenter<T> : IPresenter where T : UIView
    {
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

        public void Show() => View.Show();
        public void Hide() => View.Hide();

        public void SetVisible(bool visible)
        {
            if (visible)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        protected abstract void OnViewSet();
        protected abstract void OnViewUnSet();
    }
}