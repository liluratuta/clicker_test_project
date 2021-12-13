using UnityEngine;

namespace Clicker.Game.Bonuses
{
    [CreateAssetMenu(fileName = "Freezing Bonus", menuName = "Clicker/Bonuses/Freezing Bonus")]

    public class FreezingBonus : Bonus
    {
        public override float Duration { get; } = 5f;

        public override void Apply(IBonusSubject bonusSubject)
        {
            bonusSubject.SetFrizzing();
        }

        protected override void PerformComplete(IBonusSubject bonusSubject)
        {
            bonusSubject.CancelFrizzing();
        }
    }
}
