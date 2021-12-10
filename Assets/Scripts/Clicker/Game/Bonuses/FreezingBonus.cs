using DG.Tweening;
using UnityEngine;

namespace Clicker.Game.Bonuses
{
    public class FreezingBonus : Bonus, IBonusDisplayable
    {
        public Sprite Icon => _icon;

        [SerializeField, Min(0)] private float _duration = 5f;
        [SerializeField] private Sprite _icon;

        public override void Apply(IBonusApplicator applicator)
        {
            applicator.SetFrizzing();
            DeferredComplete(applicator, _duration);
        }

        protected override void Complete(IBonusApplicator applicator)
        {
            applicator.CancelFrizzing();
        }
    }
}
