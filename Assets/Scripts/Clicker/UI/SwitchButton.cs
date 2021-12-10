using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class SwitchButton : MonoBehaviour
    {
        public event Action<bool> Switched;
        
        private const float AnimationTime = 0.3f;
        
        [Header("Slider")]
        [SerializeField] private RectTransform _slider;
        [SerializeField] private RectTransform _sliderHolder;

        [Header("Colors")]
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _inactiveColor;
        
        private Button _button;
        private Image _image;
        private bool _isActive;

        public void SetState(bool isActive)
        {
            _isActive = isActive;
            SelectBackgroundColor(_isActive);
            SelectSliderPosition(_isActive);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        private void OnEnable() => _button.onClick.AddListener(OnButtonClicked);
        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked()
        {
            SetState(!_isActive);
            Switched?.Invoke(_isActive);
        }

        private void SelectBackgroundColor(bool isActive)
        {
            _image.DOColor(isActive ? _activeColor : _inactiveColor, AnimationTime);
        }

        private void SelectSliderPosition(bool isActive)
        {
            if (isActive == false)
            {
                _slider.DOAnchorPosX(0, AnimationTime);
                return;
            }
            
            var sliderWidth = _slider.rect.width;
            var holderWidth = _sliderHolder.rect.width;

            var sliderEndX = holderWidth - sliderWidth;

            _slider.DOAnchorPosX(sliderEndX, AnimationTime);
        }
    }
}
