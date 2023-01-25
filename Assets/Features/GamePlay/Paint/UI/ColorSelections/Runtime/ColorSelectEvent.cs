using GamePlay.Paint.Tools.Common.Definition;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    public struct ColorSelectEvent
    {
        public ColorSelectEvent(ColorDefinition color)
        {
            Color = color;
        }
        
        public readonly ColorDefinition Color;
    }
}