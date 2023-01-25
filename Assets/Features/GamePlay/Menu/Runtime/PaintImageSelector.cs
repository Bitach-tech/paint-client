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
        [SerializeField] private Button _button;

        private PaintImage _current;

        public event Action<PaintImage> Selected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void Construct(PaintImage image)
        {
            _current = image;
            _image.sprite = image.Image;
        }

        private void OnClicked()
        {
            Selected?.Invoke(_current);
        }
    }
}