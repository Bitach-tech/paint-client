using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;

namespace GamePlay.Canvases.Runtime
{
    public interface ILineFactory
    {
        ILine Create(Vector2 position, ToolType tool, LineWidth width, ColorDefinition color);
    }
}