using System.Collections.Generic;
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

            var lines = new List<Transform>();
            
            for (var i = 0; i < _linesRoot.transform.childCount; i++)
                lines.Add(_linesRoot.transform.GetChild(i));

            foreach (var line in lines)
                Destroy(line.gameObject);
        }

        public void Disable()
        {
            _sprite.gameObject.SetActive(false);
            _background.SetActive(false);
            _linesRoot.SetActive(false);
        }
    }
}