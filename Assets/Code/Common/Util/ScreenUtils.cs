using UnityEngine;

namespace Miniclip.Common.Util
{
    public static class ScreenUtils
    {
        private static Camera GetMainCamera()
        {
            _mainCamera ??= Camera.main;

            return _mainCamera;
        }

        private static Camera _mainCamera;

        public static Vector2 WorldToScreenPoint(Vector3 worldPosition)
        {
            return GetMainCamera().WorldToScreenPoint(worldPosition);
        }
    }
}