using System.Collections.Generic;

namespace GamePlay.Paint.ImageStorage.Runtime
{
    public interface IImageStorage
    {
        IReadOnlyList<PaintImage> GetImages();
    }
}