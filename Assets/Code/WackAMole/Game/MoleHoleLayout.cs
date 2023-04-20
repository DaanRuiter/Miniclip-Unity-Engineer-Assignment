using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Miniclip.Core;
using Miniclip.Util;
using UnityEngine;

namespace Miniclip.WackAMole.Game
{
    public class MoleHoleLayout : MonoBehaviour
    {
        [SerializeField] private Transform _holeContainer;
        [SerializeField] private Vector2 _holeOffset = new(0.25f, 0.25f);

        private IPrefabFactory _prefabFactory;
        private List<MoleHole> _moleHoles;

        private int _minShowDuration;
        private int _maxShowDuration;

        public void Init(IPrefabFactory prefabFactory)
        {
            _prefabFactory = prefabFactory;
            _moleHoles = new List<MoleHole>();
        }

        public void Reset()
        {
            _moleHoles.ForEach(hole => hole.SetState(MoleState.Hidden));
        }

        public void Setup(WackAMoleGameConfig gameConfig)
        {
            if (_moleHoles.Count == gameConfig.MoleHoleCount)
            {
                return;
            }

            DisposeMoleHoles();

            for (int i = 0; i < gameConfig.MoleHoleCount; i++)
            {
                var hole = SpawnMoleHole(i, gameConfig.MoleHoleCount, gameConfig.MaxHolesPerRow);

                _moleHoles.Add(hole);
            }
        }

        private MoleHole SpawnMoleHole(int holeIndex, int totalHoleCount, int maxHolesPerRow)
        {
            var hole = _prefabFactory.SpawnPrefab<MoleHole>("Game/MoleHole", _holeContainer);

            int totalRows = Mathf.CeilToInt(totalHoleCount / (float)maxHolesPerRow);

            float x = MathUtils.Mod(holeIndex, maxHolesPerRow);
            float z = Mathf.FloorToInt(holeIndex / (float)maxHolesPerRow);

            var position = new Vector3(x, 0, z);

            // Apply offset
            position.x += _holeOffset.x * x;
            position.z += _holeOffset.y * z;

            // Center
            position.x += maxHolesPerRow / -2f;
            position.z += -(totalRows - 1) / 2f;

            hole.transform.localPosition = position;

            return hole;
        }

        private void DisposeMoleHoles()
        {
            foreach (var hole in _moleHoles)
            {
                Destroy(hole.gameObject);
            }

            _moleHoles.Clear();
        }

        public MoleHole ShowRandomAvailableMole()
        {
            var mole = _moleHoles.Where(hole => hole.MoleState == MoleState.Hidden).Random();
            if (mole == null)
            {
                return null;
            }

            float showDuration = Random.Range(_minShowDuration, _maxShowDuration);
            mole.SetState(MoleState.Appearing);
            mole.SetStateDelayed(MoleState.Hiding, showDuration);

            return mole;
        }
    }
}