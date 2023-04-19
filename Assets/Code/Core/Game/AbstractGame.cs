using System;
using Miniclip.Core.Config;
using UnityEngine;

namespace Miniclip.Core
{
    public abstract class AbstractGame<T> : MonoBehaviour, IGame where T : GameConfig
    {
        public event Action RoundTimerElapsedEvent;

        protected float TimeLeft => _timerStartTimeStamp + GameConfig.SecondsPerRound - Time.time;
        protected bool IsPlaying => _isPlaying;

        protected T GameConfig;
        protected GameScoreHandle ScoreHandle;

        private int _timerStartTimeStamp;
        private bool _isPlaying;

        public abstract void Init(PrefabFactory prefabFactory);
        public abstract void SetVisible(bool visible);

        public void SetConfig(GameConfig gameConfig)
        {
            if (!(gameConfig is T specificGameConfig))
            {
                Debug.LogError($"Received game config of type {gameConfig.GetType()} but expected type {typeof(T)}");
                return;
            }

            GameConfig = specificGameConfig;
        }

        public void StartGame(GameScoreHandle scoreHandle)
        {
            ScoreHandle = scoreHandle;
            _isPlaying = true;

            OnStart();
        }

        protected virtual void Update()
        {
            if (_isPlaying && TimeLeft <= 0f)
            {
                _isPlaying = false;

                RoundTimerElapsedEvent?.Invoke();

                OnStop();
            }
        }

        protected abstract void OnStart();
        protected abstract void OnStop();
    }
}