using GamePlay.Paint.Tools.Common.Definition;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    public readonly struct WidthSelectEvent
    {
        public WidthSelectEvent(LineWidth width)
        {
            Width = width;
        }

        public readonly LineWidth Width;
    }
}