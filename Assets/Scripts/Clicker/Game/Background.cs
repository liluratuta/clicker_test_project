using UnityEngine;

namespace Clicker.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Background : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        
        public void Initialize(Sprite sprite, Vector2 size)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.size = size;
        }

        private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}