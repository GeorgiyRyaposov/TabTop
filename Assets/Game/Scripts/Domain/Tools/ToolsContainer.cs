using Assets.Game.Scripts.Core.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "ToolsContainer", menuName = "Tools/ToolsContainer")]
    public class ToolsContainer : ScriptableObject
    {
        public List<TableObjectParameters> StartObjectsParameters;

        public List<InteractionTool> ExcludedTools;
    }
}
