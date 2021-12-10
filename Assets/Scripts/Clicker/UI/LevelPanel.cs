using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(Button))]
    public class LevelPanel : MonoBehaviour
    {
        public event Action<LevelPanel> Selected;
        
        public string Title
        {
            set => _title.text = value;
        }

        public Sprite Image
        {
            set => _image.sprite = value;
        }

        public int Stars
        {
            set => _stars.SetFullness(value);
        }

        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _image;
        [SerializeField] private Stars _stars;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();
        private void OnEnable() => _button.onClick.AddListener(OnClicked);
        private void OnDisable() => _button.onClick.RemoveListener(OnClicked);
        private void OnClicked() => Selected?.Invoke(this);
    }
}
