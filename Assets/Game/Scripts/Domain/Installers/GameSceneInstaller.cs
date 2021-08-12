using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Controllers;
using Assets.Game.Scripts.Domain.Views;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Header("Prefabs")]
        public TableObject TableObj;

        [Header("GameScene")]
        public Transform TableRoot;
        public GameInputController GameInputController;

        [Header("Ui")]
        public InteractionToolView InteractionToolView;
        public SelectedToolView SelectedToolView;

        public override void InstallBindings()
        {
            //install ui
            Container.BindInstance(InteractionToolView);
            Container.BindInstance(SelectedToolView);
            
            //install game systems
            Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();

            Container.BindInstance(GameInputController);

            //install factories
            Container.BindFactory<Vector3, TableObject, TableObject.Factory>()
                .FromMonoPoolableMemoryPool(x => x.WithInitialSize(10)
                                                  .FromComponentInNewPrefab(TableObj)
                                                  .UnderTransformGroup("TableObjectsPool"));
        }
    }
}