using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    [DisallowMultipleComponent]
    public class PaintCanvasRoot : MonoBehaviour
    {
        [SerializeField] private LineFactory _lineFactory;

        public LineFactory LineFactory => _lineFactory;
    }
}