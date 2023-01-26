using GamePlay.Paint.ImageStorage.Runtime;

namespace GamePlay.Paint.Canvases.Runtime.View
{
    public interface IPaintCanvasView
    {
        public void Construct(PaintImage image);
        void Disable();
    }
}