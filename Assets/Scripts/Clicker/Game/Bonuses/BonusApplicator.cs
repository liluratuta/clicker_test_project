using Clicker.Game.Bonuses.Timelines;
using Clicker.Game.Bonuses.Timelines.ActionPoints;
using UnityEngine;

namespace Clicker.Game.Bonuses
{
    [RequireComponent(typeof(Timeline))]
    [RequireComponent(typeof(IBonusSubject))]
    public class BonusApplicator : MonoBehaviour
    {
        private Timeline _timeline;
        private IBonusSubject _bonusSubject;
        
        public void Apply(IBonus bonus)
        {
            bonus.Apply(_bonusSubject);
            var actionPoint = new CompleteBonusActionPoint(bonus, _bonusSubject);
            _timeline.AddActionPoint(actionPoint, bonus.Duration);
        }

        private void Awake()
        {
            _timeline = GetComponent<Timeline>();
            _bonusSubject = GetComponent<IBonusSubject>();
        }
    }
}
