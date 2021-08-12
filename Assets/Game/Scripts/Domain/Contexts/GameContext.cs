using Assets.Game.Scripts.Domain.Components;
using UniRx;

namespace Assets.Game.Scripts.Domain.Contexts
{
    public class GameContext 
    {
        public static GameContext Current;

        public ReactiveProperty<TableObject> SelectedObject = new ReactiveProperty<TableObject>();
    }
}
