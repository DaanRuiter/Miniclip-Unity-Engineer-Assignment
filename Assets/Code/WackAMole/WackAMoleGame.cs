using Miniclip.Core;
using Miniclip.WackAMole.Game;
using Miniclip.WackAMole.UI;
using UnityEngine;

namespace Miniclip.WackAMole
{
    public class WackAMoleGame : AbstractGame<WackAMoleGameConfig>, IPresenter
    {
        private WackAMoleGameField _gameField;
        private WackAMoleGameUIPresenter _gameUI;

        private float _nextMoleShowTimestamp;

        public override void Init(PrefabFactory prefabFactory)
        {
            _gameField = prefabFactory.SpawnPrefab<WackAMoleGameField>("Game/WackAMole - GameField");
            _gameField.InitializeGameField(prefabFactory, GameConfig);
            _gameField.MoleHitEvent += OnMoleHit;
            _gameField.EmptyHoleHitEvent += OnEmptyHoleHit;

            _gameUI = prefabFactory.SpawnUIPrefab<WackAMoleGameUIPresenter, WackAMoleGameUIView>("UI/WackAMole - GameUI");
        }

        public override void SetVisible(bool visible)
        {
            _gameUI.SetVisible(visible);
        }

        protected override void OnStart()
        {
            _gameUI.Show();
            _gameUI.Reset(GameConfig.SecondsPerRound);
            _gameField.StartGame();

            ScoreHandle.ScoreUpdatedEvent += _gameUI.SetScore;
        }

        protected override void OnStop()
        {
            ScoreHandle.ScoreUpdatedEvent -= _gameUI.SetScore;
        }

        protected override void Update()
        {
            base.Update();

            if (!IsPlaying)
            {
                return;
            }

            _gameField.ProcessInput();
            _gameUI.SetTimeLeft(TimeLeft);

            if (Time.time >= _nextMoleShowTimestamp)
            {
                ShowRandomMole();
            }
        }

        private void ShowRandomMole()
        {
            _gameField.ShowRandomMole();

            float interval = Random.Range(GameConfig.MinMoleShowIntervalSeconds, GameConfig.MaxMoleShowIntervalSeconds);
            _nextMoleShowTimestamp = Time.time + interval;
        }

        private void OnMoleHit()
        {
            ScoreHandle.AddScore(GameConfig.ScoreGainPerMoleHit);
        }

        private void OnEmptyHoleHit()
        {
            int loss = -Mathf.Abs(GameConfig.ScoreLossPerEmptyHoleHit);

            ScoreHandle.AddScore(loss);
        }
    }
}