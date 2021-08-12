using Assets.Game.Scripts.Domain.Contexts;
using Assets.Game.Scripts.Domain.Signals;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Controllers
{
    public class GameStateController : IInitializable, IDisposable
    {
        private GameInputController _gameInputSystem;
        private SignalBus _signalBus;

        //private StartScreenView _startScreenView;
        //private SettingsView _settingsView;

        public GameStateController(GameInputController gameInputSystem,
            SignalBus signalBus)
        {
            _gameInputSystem = gameInputSystem;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
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
            HideCursor(true);

            Camera.main.enabled = false; //hide camera for start screen menu

            GameContext.Current = new GameContext();

            //activate player
            //_protagonist.gameObject.SetActive(true);
            //_protagonist.Attach(GameContext.Current);

            _signalBus.Fire<NewGameStarted>();
        }

        private void HideCursor(bool hide)
        {
            Cursor.lockState = hide ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !hide;
        }
    }
}
