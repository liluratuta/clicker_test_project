using System;
using System.Collections.Generic;
using System.Linq;
using Clicker.Game;
using UnityEngine;

namespace Clicker.UI
{
    public class BonusPanel : MonoBehaviour
    {
        [SerializeField] private List<BonusTypeIconPair> _bonusTypeIconPairs = new List<BonusTypeIconPair>();

        public void SetBonusActive(BonusType bonusType, bool isActive)
        {
            _bonusTypeIconPairs.First(x => x.type == bonusType).icon.SetActive(isActive);
        }

        private void Start()
        {
            foreach (var pair in _bonusTypeIconPairs)
            {
                pair.icon.SetActive(isActive: false);
            }
        }

        [Serializable]
        private struct BonusTypeIconPair
        {
            public BonusType type;
            public BonusIcon icon;
        }
    }
}
