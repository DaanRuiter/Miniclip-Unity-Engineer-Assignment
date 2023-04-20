using Miniclip.Core;
using UnityEngine;

namespace Miniclip.WackAMole
{
    public class WackAMoleSceneWrapper : MonoBehaviour
    {
        [SerializeField] private Transform _gameContainer;
        [SerializeField] private RectTransform _UIContainer;
        [SerializeField] private WackAMoleGame _wackAMoleGame;

        private void Awake()
        {
            Main.Init(_wackAMoleGame, _gameContainer, _UIContainer);
        }

        private void Start()
        {
            Main.Start();
        }

        private void OnDestroy()
        {
            Main.Dispose();
        }
    }
}