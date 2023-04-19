using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Miniclip.WackAMole.Game
{
    public class MoleHole : MonoBehaviour
    {
        private static readonly MoleState[] HittableMoleStates = new[]
        {
            MoleState.Appearing,
            MoleState.Showing,
            MoleState.Hiding
        };

        [SerializeField] private RectTransform _mole;
        [SerializeField] private SpriteRenderer _holeSpriteRenderer;
        [SerializeField] private Animator _animator;

        public MoleState MoleState => _moleState;

        private Coroutine _delayedHideCoroutine;
        private MoleState _moleState;

        public void Reset()
        {
            if (_delayedHideCoroutine != null)
            {
                StopCoroutine(_delayedHideCoroutine);
            }

            SetState(MoleState.Hidden);
        }

        public void SetState(MoleState state)
        {
            _moleState = state;
            _animator.SetTrigger(state.ToString());
        }

        public void SetStateDelayed(MoleState state, float delay)
        {
            if (_delayedHideCoroutine != null)
            {
                StopCoroutine(_delayedHideCoroutine);
            }

            _delayedHideCoroutine = StartCoroutine(Delay());

            IEnumerator Delay()
            {
                yield return new WaitForSeconds(delay);
                SetState(state);
            }
        }

        public bool IsHittable()
        {
            return HittableMoleStates.Contains(_moleState);
        }

        // Method called by animation event
        [UsedImplicitly]
        public void OnHideAnimationCompleted()
        {
            SetState(MoleState.Hidden);
        }

        private void Awake()
        {
            Reset();
        }
    }
}