using System;
using Clicker.Game.Bonuses;
using UnityEngine;

namespace Clicker.Game.ClickTargets
{
    [RequireComponent(typeof(Collider2D))]
    public class BonusApplicator : MonoBehaviour, IBonusApplicator
    {
        public bool IsFrozen { get; private set; } = false;
        public int PointsMultiplier { get; private set; } = 1;

        [SerializeField] private ClickTargetViewAnimator _animator;
        
        private BoxCollider2D _collider2D;
        private Vector2 _originalColliderSize;

        public void Apply(IBonus bonus) => bonus.Apply(this);

        public void IncreaseSize(float increaseFactor)
        {
            _collider2D.size *= increaseFactor;
            _animator.IncreaseSize(increaseFactor);
        }

        public void SetOriginalSize()
        {
            _collider2D.size = _originalColliderSize;
            _animator.CancelResize();
        }

        public void SetPointsMultiplier(int scoreMultiplier)
        {
            PointsMultiplier = scoreMultiplier;
            _animator.ShowBonusLabel(scoreMultiplier);
        }

        public void ClearPointsMultiplier()
        {
            PointsMultiplier = 1;
            _animator.HideBonusLabel();
        }

        public void SetFrizzing()
        {
            IsFrozen = true;
            _animator.PlayShake();
        }

        public void CancelFrizzing()
        {
            IsFrozen = false;
            _animator.StopShake();
        }

        private void Awake()
        {
            _collider2D = GetComponent<BoxCollider2D>();
            _originalColliderSize = _collider2D.size;
        }
    }
}
