using System;
using Miniclip.UI.Screens;
using Miniclip.WackAMole;
using UnityEngine;

namespace Miniclip.Core
{
    /// <summary>
    /// This class represents the main entry point of this game's systems
    /// </summary>
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _gameContainer;
        [SerializeField] private RectTransform _UIContainer;

        private IGame _game;
        private GameStateService _gameStateService;
        private MainMenuPresenter _mainMenu;

        private void Awake()
        {
            var currentGame = GetComponent<IGame>();

            if (currentGame != null)
            {
                Init(currentGame);
            }
        }

        private void Start()
        {
            _gameStateService.SetGameState(GameState.Menu);
        }

        /// <summary>
        /// Calling this method with the intended game will initialize all systems and start the game flow.
        /// Can also be used from a test case
        /// </summary>
        /// <param name="game">Intended game to initialize</param>
        private void Init(IGame game)
        {
            //todo?: use some kind of installer / context for services

            var gameScoreService = new GameScoreService();
            _gameStateService = new GameStateService(game, gameScoreService);
            _gameStateService.State.ValueUpdatedEvent += OnGameStateSwitched;

            var prefabFactory = new PrefabFactory(_gameContainer, _UIContainer);

            _mainMenu = prefabFactory.SpawnUIPrefab<MainMenuPresenter, MainMenuView>("UI/MainMenu");
            _mainMenu.Init(_gameStateService);

            _game = game;
            _game.SetConfig(new WackAMoleGameConfig());
            _game.Init(prefabFactory);
        }

        private void OnGameStateSwitched(GameState state)
        {
            _mainMenu.SetVisible(state == GameState.Menu);
            _game.SetVisible(state == GameState.Game);

            Debug.Log($"Switched game state to {state}");
        }
    }
}