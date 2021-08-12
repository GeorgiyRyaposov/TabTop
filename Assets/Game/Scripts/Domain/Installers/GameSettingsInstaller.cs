using Assets.Game.Scripts.Domain.Tools;
using UnityEngine;
using Zenject;

namespace Assets.Game.Scripts.Domain.Installers
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Data/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public ToolsContainer ToolsContainer;

        public override void InstallBindings()
        {
            Container.BindInstance(ToolsContainer);
        }
    }
}
