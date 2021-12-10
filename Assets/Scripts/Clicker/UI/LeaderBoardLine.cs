using TMPro;
using UnityEngine;

namespace Clicker.UI
{
    public class LeaderBoardLine : MonoBehaviour
    {
        public string Label
        {
            set => _label.text = value;
        }

        public int Value
        {
            set => _value.text = value.ToString();
        }
        
        [SerializeField] private TMP_Text _label;
        [SerializeField] private TMP_Text _value;
    }
}
