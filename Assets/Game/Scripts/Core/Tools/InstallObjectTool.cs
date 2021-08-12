using Assets.Game.Scripts.Core.Tools.Interfaces;
using Assets.Game.Scripts.Domain.Components;
using UnityEngine;

namespace Assets.Game.Scripts.Core.Tools
{
    public class InstallObjectTool : ScriptableObject, IInstallObjectTool
    {
        public virtual void Install (TableObject tableObject) { }
    }
}