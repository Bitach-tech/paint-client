using GamePlay.Paint.ImageStorage.Runtime;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime.View
{
    [DisallowMultipleComponent]
    public class PaintCanvasView : MonoBehaviour, IPaintCanvasView
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        public void Construct(PaintImage image)
        {
            _sprite.sprite = image.Image;
        }
    }
}