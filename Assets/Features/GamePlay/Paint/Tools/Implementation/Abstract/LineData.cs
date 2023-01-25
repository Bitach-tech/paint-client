using GamePlay.Paint.Tools.Common.Definition;

namespace GamePlay.Paint.Tools.Implementation.Abstract
{
    public class LineData
    {
        private LineWidth _width;
        private ToolType _tool;
        private ColorDefinition _color;

        public LineWidth Width => _width;
        public ToolType Tool => _tool;
        public ColorDefinition Color => _color;

        public void OnWidthChanged(LineWidth width)
        {
            _width = width;
        }

        public void OnToolChanged(ToolType tool)
        {
            _tool = tool;
        }

        public void OnColorChanged(ColorDefinition color)
        {
            _color = color;
        }
    }
}