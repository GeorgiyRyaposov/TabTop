using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using Assets.Game.Scripts.Domain.Signals;
using Assets.Game.Scripts.Domain.Tools;
using Assets.Game.Scripts.Domain.Views;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Controllers
{
    public class GameStateController : IInitializable, IDisposable
    {
        private SignalBus _signalBus;
        private readonly TableObject.Factory _tableObjectsFactory;
        private readonly ToolsContainer _toolsContainer;
        private readonly InteractionToolView _interactionToolView;

        public GameStateController(
            SignalBus signalBus, TableObject.Factory tableObjectsFactory,
            ToolsContainer toolsContainer, InteractionToolView interactionToolView)
        {
            _signalBus = signalBus;
            _tableObjectsFactory = tableObjectsFactory;
            _toolsContainer = toolsContainer;
            _interactionToolView = interactionToolView;
        }

        public void Initialize()
        {
            StartNewGame();
            SetupViews();
        }
        public void Dispose()
        {

        }

        public void StartNewGame()
        {
            GameContext.Current = new GameContext();

            for (int i = 0; i < _toolsContainer.StartObjectsParameters.Count; i++)
            {
                var objectParameters = _toolsContainer.StartObjectsParameters[i];

                var tableObj = _tableObjectsFactory.Create(new Vector3(i + 0.5f, 5, 0));

                foreach (var installTool in objectParameters.InstallTools)
                {
                    installTool.Install(tableObj);
                }

                tableObj.InteractionTools.AddRange(objectParameters.InteractionTools);
            }

            _signalBus.Fire<NewGameStarted>();
        }

        private void SetupViews()
        {
            _interactionToolView.Attach(GameContext.Current);
        }
    }
}
