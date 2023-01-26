using GamePlay.Paint.Canvases.Runtime.Borders;
using GamePlay.Paint.Canvases.Runtime.Lines;
using GamePlay.Paint.Canvases.Runtime.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace GamePlay.Paint.Canvases.Runtime
{
    [DisallowMultipleComponent]
    public class PaintCanvasRoot : MonoBehaviour
    {
        [SerializeField] private LineFactory _lineFactory;
        [SerializeField] private PaintCanvasView _view;
        [FormerlySerializedAs("_borders")] [SerializeField] private Borders.PaintCanvasBorders _borderses;
        
        public LineFactory LineFactory => _lineFactory;
        public PaintCanvasView View => _view;
        public Borders.PaintCanvasBorders Borderses => _borderses;
    }
}