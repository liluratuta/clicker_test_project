using UnityEngine;

namespace Clicker.Game.Bonuses
{
    public class IncreaseBonus : Bonus, IBonusDisplayable
    {
        public Sprite Icon => _icon;

        [SerializeField, Range(1, 5)] private int _increaseFactor = 2;
        [SerializeField, Min(0)] private float _duration = 5f;
        [SerializeField] private Sprite _icon;

        public override void Apply(IBonusApplicator applicator)
        {
            applicator.IncreaseSize(_increaseFactor);
            DeferredComplete(applicator, _duration);
        }

        protected override void Complete(IBonusApplicator applicator)
        {
            applicator.SetOriginalSize();
        }
    }
}
