using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    public interface ILineFactory
    {
        ILine Create(Vector2 position, ToolType tool, LineWidth width, ColorDefinition color);
    }
}