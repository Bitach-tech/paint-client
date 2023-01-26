using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;

namespace GamePlay.Paint.Tools.Implementation.Abstract
{
    public class LineData
    {
        private LineWidth _width;
        private ToolType _tool;
        private Color _color;

        public LineWidth Width => _width;
        public ToolType Tool => _tool;
        public Color Color => _color;

        public void OnWidthChanged(LineWidth width)
        {
            _width = width;
        }

        public void OnToolChanged(ToolType tool)
        {
            _tool = tool;
        }

        public void OnColorChanged(Color color)
        {
            _color = color;
        }
    }
}