using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using Assets.Game.Scripts.Domain.Signals;
using Assets.Game.Scripts.Domain.Tools;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Controllers
{
    public class GameStateController : IInitializable, IDisposable
    {
        private GameInputController _gameInputSystem;
        private SignalBus _signalBus;
        private readonly TableObject.Factory _tableObjectsFactory;
        private readonly ToolsContainer _toolsContainer;

        //private StartScreenView _startScreenView;
        //private SettingsView _settingsView;

        public GameStateController(GameInputController gameInputSystem,
            SignalBus signalBus, TableObject.Factory tableObjectsFactory,
            ToolsContainer toolsContainer)
        {
            _gameInputSystem = gameInputSystem;
            _signalBus = signalBus;
            _tableObjectsFactory = tableObjectsFactory;
            _toolsContainer = toolsContainer;
        }

        public void Initialize()
        {
            StartNewGame();
            SetupViews();
        }
        public void Dispose()
        {

        }

        private void SetupViews()
        {
            //_startScreenView.StartGame.onClick.AddListener(OnStartNewGameClick);
            //_startScreenView.Settings.onClick.AddListener(OnShowSettingsClick);
            //_startScreenView.Quit.onClick.AddListener(Application.Quit);

            //_settingsView.ApplyButton.onClick.AddListener(OnApplySettingsClick);
            //_settingsView.RestoreDefaultsButton.onClick.AddListener(_settingsSystem.RestoreDefaultSettings);
            //_settingsView.QuitButton.onClick.AddListener(Application.Quit);

            //_startScreenView.Show();
            //_settingsView.Hide();
        }

        public void StartNewGame()
        {
            GameContext.Current = new GameContext();

            for (int i = 0; i < 10; i++)
            {
                var tableObj = _tableObjectsFactory.Create(new Vector3(i, 5, 0));

                var installTool = i % 2 == 0 ? _toolsContainer.InstallFlatMesh : _toolsContainer.InstallVolumeMesh;
                installTool.Install(tableObj);
            }

            //activate player
            //_protagonist.gameObject.SetActive(true);
            //_protagonist.Attach(GameContext.Current);

            _signalBus.Fire<NewGameStarted>();
        }
    }
}
