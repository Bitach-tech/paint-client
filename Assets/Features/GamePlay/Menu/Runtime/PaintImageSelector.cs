using System;
using GamePlay.Paint.ImageStorage.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    public class PaintImageSelector : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private GameObject _adSign;
        [SerializeField] private Button _button;

        private PaintImage _current;
        private bool _isRewardable;

        public event Action<PaintImage, bool> Selected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void Construct(PaintImage image, bool isRewardable)
        {
            _isRewardable = isRewardable;
            _current = image;
            _image.sprite = image.Image;

            if (_isRewardable == true)
                _adSign.SetActive(true);
        }

        private void OnClicked()
        {
            _adSign.SetActive(false);
            
            Selected?.Invoke(_current, _isRewardable);
            _isRewardable = false;
        }
    }
}