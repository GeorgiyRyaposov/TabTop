using Assets.Game.Scripts.Domain.Signals;
using Assets.Game.Scripts.Domain.Controllers;
using Assets.Game.Scripts.Domain.Views;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Installers
{
    public class GameInstaller : MonoInstaller
    {
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
            //Container.BindFactory<Vector3, float, ExplosionRangeVisual, ExplosionRangeVisual.Factory>()
            //    .FromMonoPoolableMemoryPool(x => x.WithInitialSize(2)
            //                                      .FromComponentInNewPrefab(ExplosionRangeVisual)
            //                                      .UnderTransformGroup("ExplosionRangeVisuals"));
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<NewGameStarted>();
        }
    }
}