using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Models;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Core.Tools
{
    public class InteractionTool : ScriptableObject
    {
        public virtual void Install(TableObject tableObject) { }

        public virtual List<ToolButtonModel> GetButtons() { return null; }
    }
}
