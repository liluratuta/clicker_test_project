using System;
using Clicker.ScriptableObjects;
using UnityEngine;

namespace Clicker.UI
{
    public class SettingsPanel : MonoBehaviour
    {
        public event Action<bool> MusicSwitched;
        public event Action<bool> SoundsSwitched;
        
        [SerializeField] private SwitchButton _musicSwitchButton;
        [SerializeField] private SwitchButton _soundsSwitchButton;
        
        public void Initialize(GameSettings gameSettings)
        {
            _musicSwitchButton.SetState(isActive: gameSettings.MusicIsActive);
            _soundsSwitchButton.SetState(isActive: gameSettings.SoundsIsActive);
        }

        private void OnEnable()
        {
            _musicSwitchButton.Switched += OnMusicSwitched;
            _soundsSwitchButton.Switched += OnSoundsSwitched;
        }
        
        private void OnDisable()
        {
            _musicSwitchButton.Switched -= OnMusicSwitched;
            _soundsSwitchButton.Switched -= OnSoundsSwitched;
        }

        private void OnMusicSwitched(bool isActive) => MusicSwitched?.Invoke(isActive);
        private void OnSoundsSwitched(bool isActive) => SoundsSwitched?.Invoke(isActive);
    }
}
