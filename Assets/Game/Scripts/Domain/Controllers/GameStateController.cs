using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Contexts;
using Assets.Game.Scripts.Domain.Tools;
using Assets.Game.Scripts.Domain.Views;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Controllers
{
    public class GameStateController : IInitializable
    {
        private readonly TableObject.Factory _tableObjectsFactory;
        private readonly ToolsContainer _toolsContainer;

        private readonly InteractionToolView _interactionToolView;
        private readonly SelectedToolView _selectedToolView;

        public GameStateController(TableObject.Factory tableObjectsFactory,
            ToolsContainer toolsContainer, InteractionToolView interactionToolView,
            SelectedToolView selectedToolView)
        {
            _tableObjectsFactory = tableObjectsFactory;
            _toolsContainer = toolsContainer;
            _interactionToolView = interactionToolView;
            _selectedToolView = selectedToolView;
        }

        public void Initialize()
        {
            StartNewGame();
            SetupViews();
        }

        public void StartNewGame()
        {
            GameContext.Current = new GameContext();

            for (int i = 0; i < _toolsContainer.StartObjectsParameters.Count; i++)
            {
                var objectParameters = _toolsContainer.StartObjectsParameters[i];

                var tableObj = _tableObjectsFactory.Create(new Vector3(i * 1.2f, 1, i % 5));

                foreach (var installTool in objectParameters.InstallTools)
                {
                    installTool.Install(tableObj);
                }

                tableObj.InteractionTools.AddRange(objectParameters.InteractionTools.Except(_toolsContainer.ExcludedTools));
            }
        }

        private void SetupViews()
        {
            _interactionToolView.Attach(GameContext.Current);
            _selectedToolView.Attach(GameContext.Current);
        }
    }
}
