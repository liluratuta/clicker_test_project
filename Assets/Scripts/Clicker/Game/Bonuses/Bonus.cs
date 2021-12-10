using DG.Tweening;
using UnityEngine;

namespace Clicker.Game.Bonuses
{
    public abstract class Bonus : ScriptableObject, IBonus
    {
        public abstract void Apply(IBonusApplicator applicator);

        protected abstract void Complete(IBonusApplicator applicator);

        protected void DeferredComplete(IBonusApplicator applicator, float duration)
        {
            DOTween.Sequence().AppendInterval(duration).AppendCallback(() => Complete(applicator));
        }
    }
}
