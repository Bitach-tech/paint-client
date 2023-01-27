using GamePlay.Paint.Canvases.Runtime.Borders;
using GamePlay.Paint.Canvases.Runtime.Lines;
using GamePlay.Paint.Canvases.Runtime.View;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    [DisallowMultipleComponent]
    public class PaintCanvasRoot : MonoBehaviour
    {
        [SerializeField] private LineFactory _lineFactory;
        [SerializeField] private PaintCanvasView _view;
        [SerializeField] private PaintCanvasBorders _borders;
        
        public LineFactory LineFactory => _lineFactory;
        public PaintCanvasView View => _view;
        public PaintCanvasBorders Borders => _borders;
    }
}