using Clicker.Mediators;
using Clicker.ScriptableObjects;
using UnityEngine;

namespace Clicker.Settings
{
    public class SettingsHolder : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Mediator _mediator;
        
        public void ChangeMusicSetting(bool isActive)
        {
            _gameSettings.MusicIsActive = isActive;
            _mediator.SetMusicState(isActive);
        }
        
        public void ChangeSoundsSetting(bool isActive)
        {
            _gameSettings.SoundsIsActive = isActive;
        }

        private void Start()
        {
            _mediator.SetMusicState(_gameSettings.MusicIsActive);
        }
    }
}
