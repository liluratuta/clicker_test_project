using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    public class ScreenAnimator : MonoBehaviour
    {
        [Header("Canvas Group")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField, Min(0)] private float _canvasGroupAppearanceTime = 0.5f;

        [Header("Blackout")]
        [SerializeField] private Image _blackout;
        [SerializeField, Range(0f, 1f)] private float _finishAlpha;
        [SerializeField, Min(0)] private float _blackoutAppearanceTime = 0.5f;

        public void AnimateAppearance()
        {
            HideAll();

            var sequence = DOTween.Sequence();
            sequence.Append(_blackout.DOFade(_finishAlpha, _blackoutAppearanceTime));
            sequence.Append(_canvasGroup.DOFade(1f, _canvasGroupAppearanceTime));
        }

        private void HideAll()
        {
            _canvasGroup.alpha = 0;
            
            var blackoutColor = _blackout.color;
            blackoutColor.a = 0;
            _blackout.color = blackoutColor;
        }
    }
}
