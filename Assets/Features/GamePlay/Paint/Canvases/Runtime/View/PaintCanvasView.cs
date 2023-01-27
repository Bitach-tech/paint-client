using System;
using GamePlay.Paint.ImageStorage.Runtime;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime.View
{
    [DisallowMultipleComponent]
    public class PaintCanvasView : MonoBehaviour, IPaintCanvasView
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private GameObject _background;
        [SerializeField] private GameObject _linesRoot;
        
        private void Awake()
        {
            Disable();
        }

        public void Construct(PaintImage image)
        {
            _sprite.gameObject.SetActive(true);
            _background.SetActive(true);
            _linesRoot.SetActive(true);
            _sprite.sprite = image.Image;
        }

        public void Disable()
        {
            _sprite.gameObject.SetActive(false);
            _background.SetActive(false);
            _linesRoot.SetActive(false);
        }
    }
}