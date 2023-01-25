using System;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.Canvases.Runtime
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

        private LineWidthConfigAsset _config;

        public ILine Create(Vector2 position, ToolType tool, LineWidth widthType, ColorDefinition color)
        {
            var linePrefab = tool switch
            {
                ToolType.Brush => _brush,
                ToolType.Pen => _pencil,
                ToolType.Marker => _marker,
                _ => throw new ArgumentOutOfRangeException(nameof(tool), tool, null)
            };

            var width = _config.Widths[widthType];

            var line = Instantiate(linePrefab, position, Quaternion.identity, _root);
            line.Construct(position, width, color.Color);

            return line;
        }
    }
}