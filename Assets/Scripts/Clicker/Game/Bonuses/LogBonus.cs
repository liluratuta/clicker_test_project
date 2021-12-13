using UnityEngine;

namespace Clicker.Game.Bonuses
{
    public class LogBonus : IBonus
    {
        public float Duration { get; }

        private readonly int _id;
        private float _startTime;

        public LogBonus(float duration)
        {
            Duration = duration;
            _id = Random.Range(100, 1000);
        }

        public void Apply(IBonusSubject bonusSubject)
        {
            _startTime = Time.time;
            Debug.Log($"LogBonus({_id}). StartTime: {_startTime}, Duration:{Duration}");
        }

        public void Complete(IBonusSubject bonusSubject)
        {
            var currentTime = Time.time;
            var realDuration = currentTime - _startTime;
            
            Debug.Log($"LogBonus({_id}). FinishTime:{currentTime}, RealDuration:{realDuration}");
        }
    }
}