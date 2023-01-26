using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime.Borders
{
    public interface IPaintCanvasBorders
    {
        bool IsInBorders(Vector2 position);
    }
}