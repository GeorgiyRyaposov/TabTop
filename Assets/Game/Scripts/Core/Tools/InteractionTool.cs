using Assets.Game.Scripts.Core.Tools.Interfaces;
using Assets.Game.Scripts.Domain.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Core.Tools
{
    public class InteractionTool : ScriptableObject, IInteractionTool
    {
        public virtual List<ToolButtonModel> GetButtons() { return null; }
    }
}
