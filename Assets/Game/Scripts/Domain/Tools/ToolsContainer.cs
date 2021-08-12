using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "ToolsContainer", menuName = "Tools/ToolsContainer")]
    public class ToolsContainer : ScriptableObject
    {
        public List<TableObjectParameters> StartObjectsParameters;

        [Header("InteractionTools")]
        public FlipTool FlipTool;
    }
}
