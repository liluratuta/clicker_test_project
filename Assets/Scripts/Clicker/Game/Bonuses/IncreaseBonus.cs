using UnityEngine;

namespace Clicker.Game.Bonuses
{
    [CreateAssetMenu(fileName = "Increase Bonus", menuName = "Clicker/Bonuses/Increase Bonus")]
    public class IncreaseBonus : Bonus
    {
        private const int IncreaseFactor = 2;
        
        public override float Duration { get; } = 5;

        public override void Apply(IBonusSubject bonusSubject)
        {
            bonusSubject.IncreaseSize(IncreaseFactor);
        }

        protected override void PerformComplete(IBonusSubject bonusSubject)
        {
            bonusSubject.SetOriginalSize();
        }
    }
}
