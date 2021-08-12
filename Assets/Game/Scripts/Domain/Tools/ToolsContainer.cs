using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "ToolsContainer", menuName = "Tools/ToolsContainer")]
    public class ToolsContainer : ScriptableObject
    {
        public InstallMeshTool InstallFlatMesh;
        public InstallMeshTool InstallVolumeMesh;
    }
}
