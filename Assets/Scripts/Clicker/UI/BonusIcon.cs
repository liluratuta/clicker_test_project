using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    public class BonusIcon : MonoBehaviour
    {
        public Sprite Sprite
        {
            set => _icon.sprite = value;
        }
        
        [SerializeField] private Image _icon;
    }
}
