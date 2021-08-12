using UniRx;

namespace Assets.Game.Scripts.Domain.Contexts
{
    public class GameContext 
    {
        public static GameContext Current;

        public IntReactiveProperty Points = new IntReactiveProperty();
    }
}
