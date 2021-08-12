using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Controllers;
using Assets.Game.Scripts.Domain.Signals;
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

        [Header("Ui")]
        public Transform UiRoot;

        public override void InstallBindings()
        {
            InstallSignals();

            //install ui
            //Container.BindInstance(StartScreenView);
            //Container.BindInstance(SettingsView);
            //Container.BindInstance(PointsView);

            //install game systems
            Container.BindInterfacesAndSelfTo<GameStateController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameInputController>().AsSingle();

            //Container.BindInstance(Protagonist);

            //install factories
            Container.BindFactory<Vector3, TableObject, TableObject.Factory>()
                .FromMonoPoolableMemoryPool(x => x.WithInitialSize(10)
                                                  .FromComponentInNewPrefab(TableObj)
                                                  .UnderTransformGroup("TableObjectsPool"));
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<NewGameStarted>();
        }
    }
}