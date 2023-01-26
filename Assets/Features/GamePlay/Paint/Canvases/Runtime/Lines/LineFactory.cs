using System;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.Canvases.Runtime.Lines
{
    [DisallowMultipleComponent]
    public class LineFactory : MonoBehaviour, ILineFactory
    {
        [Inject]
        private void Construct(LineWidthConfigAsset config)
        {
            _config = config;
        }

        [SerializeField] private Transform _root;

        [SerializeField] private Line _brush;
        [SerializeField] private Line _pencil;
        [SerializeField] private Line _marker;
        [SerializeField] private Line _eraser;

        private LineWidthConfigAsset _config;

        private int _order;

        public ILine Create(Vector2 position, ToolType tool, LineWidth widthType, Color color)
        {
            var linePrefab = tool switch
            {
                ToolType.Brush => _brush,
                ToolType.Pen => _pencil,
                ToolType.Marker => _marker,
                ToolType.Eraser => _eraser,
                _ => throw new ArgumentOutOfRangeException(nameof(tool), tool, null)
            };

            var width = _config.Widths[widthType];

            _order++;
            
            var line = Instantiate(linePrefab, Vector3.zero, Quaternion.identity, _root);
            line.Construct(position, width, color, _order);

            return line;
        }
    }
}