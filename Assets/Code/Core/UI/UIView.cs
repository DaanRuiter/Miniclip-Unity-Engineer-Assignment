using UnityEngine;

namespace Miniclip.Core.UI
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

        public void Open() => gameObject.SetActive(true);

        public void Close() => gameObject.SetActive(false);
    }
}