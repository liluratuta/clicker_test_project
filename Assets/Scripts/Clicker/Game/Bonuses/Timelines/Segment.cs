using Clicker.Game.Bonuses.Timelines.ActionPoints;

namespace Clicker.Game.Bonuses.Timelines
{
    public class Segment
    {
        public float Duration { get; }
        
        private readonly IActionPoint _actionPoint;

        public Segment(IActionPoint actionPoint, float duration)
        {
            _actionPoint = actionPoint;
            Duration = duration;
        }

        public Segment(Segment segment, float duration)
        {
            _actionPoint = segment._actionPoint;
            Duration = duration;
        }

        public void Complete() => _actionPoint.Execute();
    }
}