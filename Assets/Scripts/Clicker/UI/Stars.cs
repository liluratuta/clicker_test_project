using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker.UI
{
    public class Stars : MonoBehaviour
    {
        private List<Star> _stars = new List<Star>();

        public void SetFullness(int fullness)
        {
            if (fullness < 0 || fullness > _stars.Count)
            {
                throw new Exception("Incorrect fullness value");
            }

            for (var i = 0; i < _stars.Count; i++)
            {
                var isActiveStar = i < fullness;
                _stars[i].SetState(isActiveStar ? StarState.Active : StarState.Empty);
            }
        }
        
        private void Awake() => GetComponentsInChildren(_stars);
    }
}
