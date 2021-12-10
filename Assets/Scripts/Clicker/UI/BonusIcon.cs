using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(Image))]
    public class BonusIcon : MonoBehaviour
    {
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _inactiveColor;

        private Image _image;

        public void SetActive(bool isActive) => _image.color = isActive ? _activeColor : _inactiveColor;

        private void Awake() => _image = GetComponent<Image>();
    }
}
