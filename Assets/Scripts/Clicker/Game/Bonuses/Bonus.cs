using System;
using UnityEngine;

namespace Clicker.Game.Bonuses
{
    public abstract class Bonus : ScriptableObject, IBonus, IBonusView
    {
        public event Action<Bonus> Completed;
        
        public Sprite Icon => _icon;
        public abstract float Duration { get; }
        
        [SerializeField] private Sprite _icon;
        
        public abstract void Apply(IBonusSubject bonusSubject);

        public void Complete(IBonusSubject bonusSubject)
        {
            PerformComplete(bonusSubject);
            Completed?.Invoke(this);
        }

        protected abstract void PerformComplete(IBonusSubject bonusSubject);
    }
}