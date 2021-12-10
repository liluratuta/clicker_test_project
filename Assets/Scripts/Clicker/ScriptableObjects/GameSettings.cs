using UnityEngine;

namespace Clicker.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "Clicker/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public bool MusicIsActive
        {
            get => _musicIsActive;
            set => _musicIsActive = value;
        }

        public bool SoundsIsActive
        {
            get => _soundsIsActive;
            set => _soundsIsActive = value;
        }

        [SerializeField] private bool _musicIsActive;
        [SerializeField] private bool _soundsIsActive;
    }
}
