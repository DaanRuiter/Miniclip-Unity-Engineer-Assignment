using Miniclip.Core;
using Miniclip.Scoring;
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

        /// <summary>
        /// Allows a game to set specific types/implementations for each of the system required interfaces
        /// </summary>
        /// <returns></returns>
        public override SystemBindings GetSystemBindings()
        {
            var scoreService = new GameScoreService(new PlayerPrefScoreLoader(), new PlayerPrefScoreSaver());
            var gameStateService = new GameStateService(this, scoreService);
            var prefabFactory = new PrefabFactory();

            return new SystemBindings(gameStateService, scoreService, prefabFactory, new WackAMoleGameConfig());
        }

        public override void Init(IPrefabFactory prefabFactory)
        {
            _gameField = prefabFactory.SpawnPrefab<WackAMoleGameField>("Game/WackAMole - GameField");
            _gameField.InitializeGameField(prefabFactory, GameConfig);
            _gameField.MoleHitEvent += OnMoleHit;
            _gameField.EmptyHoleHitEvent += OnEmptyHoleHit;

            _gameUI =
                prefabFactory.SpawnUIPresenter<WackAMoleGameUIPresenter, WackAMoleGameUIView>("UI/WackAMole - GameUI");
        }

        public override void SetVisible(bool visible)
        {
            _gameUI.SetVisible(visible);
        }

        protected override void OnStart()
        {
            _gameUI.Open();
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
            int gain = GameConfig.ScoreGainPerMoleHit;

            ScoreHandle.AddScore(gain);

            _gameUI.SpawnFloatingScoreDisplay(gain);
        }

        private void OnEmptyHoleHit()
        {
            int loss = -Mathf.Abs(GameConfig.ScoreLossPerEmptyHoleHit);

            ScoreHandle.AddScore(loss);

            _gameUI.SpawnFloatingScoreDisplay(loss);
        }
    }
}