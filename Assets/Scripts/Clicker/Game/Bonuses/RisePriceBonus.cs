using UnityEngine;

namespace Clicker.Game.Bonuses
{
    [CreateAssetMenu(fileName = "Rise Price Bonus", menuName = "Clicker/Bonuses/Rise Price Bonus")]
    public class RisePriceBonus : Bonus
    {
        private const int ScoreMultiplier = 2;
        public override float Duration { get; } = 5f;

        public override void Apply(IBonusSubject bonusSubject)
        {
            bonusSubject.SetPointsMultiplier(ScoreMultiplier);
        }
        
        protected override void PerformComplete(IBonusSubject bonusSubject)
        {
            bonusSubject.ClearPointsMultiplier();
        }
    }
}
