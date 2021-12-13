using System;
using System.Collections.Generic;
using Clicker.Game.Bonuses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Clicker.Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BonusBox : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;
        
        public Vector2 Size => _collider.size;
        public List<Bonus> Bonuses => _bonuses;

        public Sprite Icon
        {
            set => _view.sprite = value;
        }

        public Vector2 Position
        {
            set => transform.position = value;
        }

        [SerializeField] private List<Bonus> _bonuses = new List<Bonus>();
        [SerializeField] private SpriteRenderer _view;
        private BoxCollider2D _collider;

        private void Awake() => _collider = GetComponent<BoxCollider2D>();

        public void OnPointerClick(PointerEventData eventData) => Clicked?.Invoke();
    }
}
