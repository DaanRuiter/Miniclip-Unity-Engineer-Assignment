using System;
using UnityEngine;

namespace Miniclip.Common.Input
{
    public class TapHandler
    {
        private const int DefaultRaycastDistance = 100;

        public event Action<Vector2> ScreenTappedEvent;

        private Camera _cachedMainCamera;

        public TapHandler(Camera mainCamera)
        {
            _cachedMainCamera = mainCamera;
        }

        public void CheckForInput()
        {
#if UNITY_EDITOR
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                ScreenTappedEvent?.Invoke(UnityEngine.Input.mousePosition);
            }

            return;
#endif

            foreach (var touch in UnityEngine.Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    ScreenTappedEvent?.Invoke(touch.position);
                }
            }
        }

        public bool TryFindGameObjectUnderTouch(Vector2 touchPosition,
            string targetLayer,
            out GameObject hitTarget,
            int raycastDistance = DefaultRaycastDistance)
        {
            var ray = _cachedMainCamera.ScreenPointToRay(touchPosition);

            if (Physics.Raycast(ray, out var hit, raycastDistance, LayerMask.GetMask(targetLayer)))
            {
                hitTarget = hit.transform.gameObject;
            }
            else
            {
                hitTarget = null;
            }

            return hitTarget != null;
        }
    }
}