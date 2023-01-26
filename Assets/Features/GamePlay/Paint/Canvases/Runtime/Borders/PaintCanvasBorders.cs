using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime.Borders
{
    [DisallowMultipleComponent]
    public class PaintCanvasBorders : MonoBehaviour, IPaintCanvasBorders
    {
        [SerializeField] private Transform _leftDown;
        [SerializeField] private Transform _rightTop;
        
        public bool IsInBorders(Vector2 position)
        {
            if (position.x < _leftDown.position.x)
                return false;
            
            if (position.y < _leftDown.position.y)
                return false;

            if (position.x > _rightTop.position.x)
                return false;
            
            if (position.y > _rightTop.position.y)
                return false;
            
            return true;
        }
    }
}