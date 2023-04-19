using System;
using Miniclip.Core;
using Miniclip.Input;
using UnityEngine;

namespace Miniclip.WackAMole.Game
{
    public class WackAMoleGameField : MonoBehaviour
    {
        private const string MoleLayerName = "Mole";

        public event Action MoleHitEvent;
        public event Action EmptyHoleHitEvent;

        [SerializeField] private MoleHoleLayout _moleHoleLayout;

        private TapHandler _tapHandler;

        public void InitializeGameField(PrefabFactory prefabFactory, WackAMoleGameConfig gameConfig)
        {
            _moleHoleLayout.Init(prefabFactory);
            _moleHoleLayout.Setup(gameConfig);

            _tapHandler = new TapHandler(Camera.main);
            _tapHandler.ScreenTappedEvent += OnScreenTapped;
        }

        public void ShowRandomMole()
        {
            _moleHoleLayout.ShowRandomAvailableMole();
        }

        public void StartGame()
        {
            _moleHoleLayout.Reset();
        }

        public void ProcessInput()
        {
            _tapHandler.CheckForInput();
        }

        private void OnScreenTapped(Vector2 position)
        {
            if (!_tapHandler.TryFindGameObjectUnderTouch(position, MoleLayerName, out var hitTarget))
            {
                return;
            }

            var hitBox = hitTarget.GetComponent<MoleHitBox>();
            if (hitBox == null)
            {
                return;
            }

            if (hitBox.MoleHole.IsHittable())
            {
                hitBox.MoleHole.SetState(MoleState.Hit);

                MoleHitEvent?.Invoke();
            }
            else if (hitBox.MoleHole.MoleState != MoleState.Hit)
            {
                EmptyHoleHitEvent?.Invoke();
            }
        }
    }
}