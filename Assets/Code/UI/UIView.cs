using UnityEngine;

namespace Miniclip.UI
{
    public abstract class UIView : MonoBehaviour
    {
        public RectTransform RectTransform
        {
            get
            {
                if (_cachedRectTransform == null)
                {
                    _cachedRectTransform = GetComponent<RectTransform>();
                }

                return _cachedRectTransform;
            }
        }

        private RectTransform _cachedRectTransform;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}