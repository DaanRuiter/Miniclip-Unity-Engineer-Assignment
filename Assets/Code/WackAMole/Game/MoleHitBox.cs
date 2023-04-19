using UnityEngine;

namespace Miniclip.WackAMole.Game
{
    public class MoleHitBox : MonoBehaviour
    {
        [SerializeField] private MoleHole _moleHole;

        public MoleHole MoleHole => _moleHole;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_moleHole == null)
            {
                _moleHole = GetComponentInParent<MoleHole>();
            }
        }
#endif
    }
}