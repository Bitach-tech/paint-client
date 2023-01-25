using GamePlay.Paint.Tools.Common.Definition;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    public readonly struct ToolSelectEvent
    {
        public ToolSelectEvent(ToolType tool)
        {
            Tool = tool;
        }
        
        public readonly ToolType Tool;
    }
}