using Assets.Game.Scripts.Core.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Domain.Tools
{
    [CreateAssetMenu(fileName = "TableObjectParameters", menuName = "Tools/TableObjectParameters")]
    public class TableObjectParameters : ScriptableObject
    {
        public List<InstallObjectTool> InstallTools;
        public List<InteractionTool> InteractionTools;
    }
}
