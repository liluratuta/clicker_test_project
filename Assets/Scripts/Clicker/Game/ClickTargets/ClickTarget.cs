using System;
using Clicker.Game.Bonuses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker.Game.ClickTargets
{
    [RequireComponent(typeof(BonusApplicator))]
    [RequireComponent(typeof(Collider2D))]
    public class ClickTarget : MonoBehaviour, IPointerClickHandler
    {
        public event Action<int> PointsEarned;
        public Vector2 Size => _collider2D.bounds.size;

        public Sprite Sprite
        {
            set => _view.sprite = value;
        }

        private const int PointsPerClick = 1;

        [SerializeField] private SpriteRenderer _view;
        private Transform _transform;
        private BonusApplicator _bonusApplicator;
        private Collider2D _collider2D;

        public void SetPosition(Vector2 position) => _transform.position = position;

        public bool IsChangePositionPossible() => !_bonusApplicator.IsFrozen;

        public void ApplyBonus(IBonus bonus) => _bonusApplicator.Apply(bonus);

        private void Awake()
        {
            _transform = transform;
            _bonusApplicator = GetComponent<BonusApplicator>();
            _collider2D = GetComponent<Collider2D>();
        }

        public void OnPointerClick(PointerEventData eventData) => PointsEarned?.Invoke(PointsPerClick * _bonusApplicator.PointsMultiplier);
    }
}
