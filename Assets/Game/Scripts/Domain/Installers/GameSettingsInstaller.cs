using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Data/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        //public WeaponsList WeaponsList;

        public override void InstallBindings()
        {
            //foreach (var weapon in WeaponsList.Items)
            //{
            //    Container.QueueForInject(weapon.Bullet);
            //}

            //Container.BindInstance(WeaponsList);
            //Container.BindInstance(EnemyMask);
        }
    }
}
