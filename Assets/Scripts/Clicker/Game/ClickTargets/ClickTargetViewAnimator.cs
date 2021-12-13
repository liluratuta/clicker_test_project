using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Clicker.Game.ClickTargets
{
    public class ClickTargetViewAnimator : MonoBehaviour
    {
        private readonly Vector2 _originalSize = Vector2.one;
        private readonly float _animationTime = 0.5f;
        private readonly Vector3 _originalPosition = Vector3.zero;

        [SerializeField] private TMP_Text _bonusLabel;
        
        private Transform _transform;
        private Coroutine _shakeCoroutine;
        private Coroutine _fadingCoroutine;

        [ContextMenu("Resize 2X")]
        public void Resize2X() => Resize(Vector2.one * 2f);
        public void Resize(Vector2 size) => _transform.DOScale(size, _animationTime).SetEase(Ease.InOutBack);
        [ContextMenu("Cancel Resize")]
        public void CancelResize() => _transform.DOScale(_originalSize, _animationTime).SetEase(Ease.InOutBack);

        [ContextMenu("Play Shake")]
        public void PlayShake() => _shakeCoroutine = StartCoroutine(Shaking());

        [ContextMenu("Stop Shake")]
        public void StopShake()
        {
            StopCoroutine(_shakeCoroutine);
            _transform.localPosition = _originalPosition;
        }
        
        [ContextMenu("Show Bonus Label")]
        public void Show2XBonusLabel()
        {
            ShowBonusLabel(2);
        }

        public void ShowBonusLabel(int scoreMultiplier)
        {
            _bonusLabel.enabled = true;
            _bonusLabel.text = $"{scoreMultiplier}X";
            _fadingCoroutine = StartCoroutine(BonusLabelFading());
        }

        [ContextMenu("Hide Bonus Label")]
        public void HideBonusLabel()
        {
            StopCoroutine(_fadingCoroutine);
            _bonusLabel.enabled = false;
        }

        private void Awake() => _transform = GetComponent<Transform>();

        private IEnumerator Shaking()
        {
            var position = _originalPosition;
            Vector3 randomOffset;
            
            while (true)
            {
                randomOffset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1)) * 4;
                position += randomOffset * Time.deltaTime;
                position = Vector3.Lerp(_originalPosition, position, 0.4f);
                
                _transform.localPosition = position;

                yield return null;
            }
        }

        private IEnumerator BonusLabelFading()
        {
            var color = _bonusLabel.color;
            
            while (true)
            {
                color.a = Mathf.PingPong(Time.time, 1f);
                
                _bonusLabel.color = color;
                yield return null;
            }
        }
    }
}
