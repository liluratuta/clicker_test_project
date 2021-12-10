using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(Image))]
    public class Star : MonoBehaviour
    {
        [SerializeField] private Sprite _emptyStarSprite;
        [SerializeField] private Sprite _activeStarSprite;

        private Image _image;
        
        public void SetState(StarState state)
        {
            _image.sprite = state switch
            {
                StarState.Empty => _emptyStarSprite,
                StarState.Active => _activeStarSprite,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }

        private void Awake() => _image = GetComponent<Image>();
    }
}
