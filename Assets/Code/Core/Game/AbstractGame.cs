﻿using System;
using Miniclip.Core.Config;
using Miniclip.Core.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Miniclip.Core
{
    public abstract class AbstractGame<T> : MonoBehaviour, IGame where T : GameConfig
    {
        public event Action<IScoreHandle> GameOverEvent;

        protected float TimeLeft => _timerStartTimeStamp + GameConfig.SecondsPerRound - Time.time;

        protected bool IsPlaying => _isPlaying;

        protected T GameConfig;
        protected IScoreHandle ScoreHandle;

        private float _timerStartTimeStamp;
        private bool _isPlaying;

        public abstract SystemBindings GetSystemBindings();

        public abstract void Init(IPrefabFactory prefabFactory);

        public abstract void SetVisible(bool visible);

        public void Destroy()
        {
            Object.Destroy(gameObject);
        }

        public void SetConfig(GameConfig gameConfig)
        {
            if (!(gameConfig is T specificGameConfig))
            {
                Debug.LogError($"Received game config of type {gameConfig.GetType()} but expected type {typeof(T)}");
                return;
            }

            GameConfig = specificGameConfig;
        }

        public void StartGame(IScoreHandle scoreHandle)
        {
            ScoreHandle = scoreHandle;
            _isPlaying = true;
            _timerStartTimeStamp = Time.time;

            OnStart();
        }

        protected virtual void Update()
        {
            if (_isPlaying && TimeLeft <= 0f)
            {
                _isPlaying = false;

                GameOverEvent?.Invoke(ScoreHandle);

                OnStop();
            }
        }

        protected abstract void OnStart();

        protected abstract void OnStop();
    }
}