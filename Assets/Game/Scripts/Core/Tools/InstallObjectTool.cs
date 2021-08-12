using Assets.Game.Scripts.Domain.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Core.Tools
{
    public class InstallObjectTool : ScriptableObject
    {
        public virtual void Install (TableObject tableObject) { }
    }
}