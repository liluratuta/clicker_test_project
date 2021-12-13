using System.Collections.Generic;
using Clicker.Game.Bonuses;
using UnityEngine;

namespace Clicker.UI
{
    public class BonusPanel : MonoBehaviour
    {
        private readonly Dictionary<IBonusView, BonusIcon> _icons = new Dictionary<IBonusView, BonusIcon>();
        [SerializeField] private BonusIcon _bonusIconPrefab;

        public void SetBonusActive(IBonusView bonusView, bool isActive)
        {
            if (isActive)
            {
                AddBonusIcon(bonusView);
                return;
            }

            if (!IsExistBonusIcon(bonusView)) return;
            
            RemoveBonusIcon(bonusView);
        }

        private bool IsExistBonusIcon(IBonusView bonusView)
        {
            return _icons.ContainsKey(bonusView);
        }

        private void RemoveBonusIcon(IBonusView bonusView)
        {
            var image = _icons[bonusView];
            _icons.Remove(bonusView);
            Destroy(image.gameObject);
        }

        private void AddBonusIcon(IBonusView bonusView)
        {
            var icon = Instantiate(_bonusIconPrefab, transform);
            icon.Sprite = bonusView.Icon;
            _icons.Add(bonusView, icon);
        }
    }
}
