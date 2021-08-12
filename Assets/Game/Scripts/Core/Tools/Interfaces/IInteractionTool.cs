using Assets.Game.Scripts.Domain.Components;
using Assets.Game.Scripts.Domain.Models;
using System.Collections.Generic;

namespace Assets.Game.Scripts.Core.Tools.Interfaces
{
    public interface IInteractionTool
    {
        List<ToolButtonModel> GetButtons();
    }
}
