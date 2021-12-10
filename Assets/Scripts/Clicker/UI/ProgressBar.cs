using DG.Tweening;
using UnityEngine;

namespace Clicker.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _fillRectTransform;
        private RectTransform _rectTransform;
        
        public void SetFullness(float fullness)
        {
            var width = _rectTransform.rect.width;
            var fillSize = _fillRectTransform.sizeDelta;

            fillSize.x = width * fullness;

            _fillRectTransform.DOSizeDelta(fillSize, 0.5f).SetEase(Ease.InBounce);
        }

        private void Awake() => _rectTransform = GetComponent<RectTransform>();
    }
}
