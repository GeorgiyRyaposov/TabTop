using Assets.Game.Scripts.Domain.Components;

namespace Assets.Game.Scripts.Domain.Models
{
    [System.Serializable]
    public class ToolButtonModel
    {
        public string Name;
        public System.Action<TableObject> OnClick;
    }
}