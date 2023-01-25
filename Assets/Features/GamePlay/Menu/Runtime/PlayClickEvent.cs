using GamePlay.Paint.ImageStorage.Runtime;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayClickEvent
    {
        public PlayClickEvent(PaintImage image)
        {
            Image = image;
        }

        public readonly PaintImage Image;
    }
}