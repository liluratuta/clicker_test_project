using Clicker.Mediators;
using Clicker.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(ScreenAnimator))]
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Mediator _mediator;
        [SerializeField] private SettingsPanel _settingsPanel;
        [SerializeField] private Button _closeButton;

        private ScreenAnimator _screenAnimator;
        
        public void Display(GameSettings gameSettings)
        {
            gameObject.SetActive(true);
            _settingsPanel.Initialize(gameSettings);
            _screenAnimator.AnimateAppearance();
        }

        public void Hide() => gameObject.SetActive(false);

        private void Awake() => _screenAnimator = GetComponent<ScreenAnimator>();
        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
            _settingsPanel.MusicSwitched += _mediator.ChangeMusicSetting;
            _settingsPanel.SoundsSwitched += _mediator.ChangeSoundsSetting;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
            _settingsPanel.MusicSwitched -= _mediator.ChangeMusicSetting;
            _settingsPanel.SoundsSwitched -= _mediator.ChangeSoundsSetting;
        }
    }
}
