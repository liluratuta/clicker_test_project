using System;
using Clicker.Game.Bonuses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker.Game.ClickTargets
{
    [RequireComponent(typeof(BonusApplicator))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ClickTarget : MonoBehaviour, IPointerClickHandler, IBonusSubject
    {
        public event Action<int> PointsEarned;
        public Vector2 Size => _collider2D.bounds.size;

        public Sprite Sprite
        {
            set => _view.sprite = value;
        }

        [SerializeField] private SpriteRenderer _view;
        [SerializeField] private ClickTargetViewAnimator _animator;

        private const int PointsPerClick = 1;
        private readonly Vector2 _originalSize = Vector2.one;

        private Transform _transform;
        private BonusApplicator _bonusApplicator;
        private BoxCollider2D _collider2D;
        private int _pointsMultiplier = 1;
        private bool _isFrozen = false;

        public void SetPosition(Vector2 position) => _transform.position = position;

        public bool IsChangePositionPossible() => !_isFrozen;

        public void ApplyBonus(IBonus bonus) => _bonusApplicator.Apply(bonus);

        private void Awake()
        {
            _transform = transform;
            _bonusApplicator = GetComponent<BonusApplicator>();
            _collider2D = GetComponent<BoxCollider2D>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointsEarned?.Invoke(PointsPerClick * _pointsMultiplier);
        }

        public void SetOriginalSize()
        {
            _collider2D.size = _originalSize;
            _animator.CancelResize();
        }

        public void IncreaseSize(int increaseFactor)
        {
            var increasedSize = _originalSize * increaseFactor;
            _collider2D.size = increasedSize;
            _animator.Resize(increasedSize);
        }

        public void SetPointsMultiplier(int pointsMultiplier)
        {
            _pointsMultiplier = pointsMultiplier;
            _animator.ShowBonusLabel(pointsMultiplier);
        }

        public void ClearPointsMultiplier()
        {
            SetPointsMultiplier(1);
            _animator.HideBonusLabel();
        }

        public void SetFrizzing()
        {
            _isFrozen = true;
            _animator.PlayShake();
        }

        public void CancelFrizzing()
        {
            _isFrozen = false;
            _animator.StopShake();
        }
    }
}
