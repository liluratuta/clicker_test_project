using Clicker.ScriptableObjects;
using Clicker.Settings;
using Clicker.UI;
using UnityEngine;

namespace Clicker.Mediators
{
    public abstract class Mediator : MonoBehaviour
    {
        [SerializeField] private SettingsHolder _settingsHolder;
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private AudioSource _musicAudioSource;
        
        public void ChangeMusicSetting(bool isActive) => _settingsHolder.ChangeMusicSetting(isActive);
        public void ChangeSoundsSetting(bool isActive) => _settingsHolder.ChangeSoundsSetting(isActive);
        
        public void DisplaySettingsScreen(GameSettings gameSettings) => _settingsScreen.Display(gameSettings);
        public void HideSettingsScreen() => _settingsScreen.Hide();
        public void SetMusicState(bool isActive) => _musicAudioSource.volume = isActive ? 1 : 0;
    }
}
