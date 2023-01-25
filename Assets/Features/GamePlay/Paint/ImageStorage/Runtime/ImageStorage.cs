using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.ImageStorage.Runtime
{
    [DisallowMultipleComponent]
    public class ImageStorage : MonoBehaviour, IImageStorage
    {
        [Inject]
        private void Construct(PaintImage[] images)
        {
            _images = images;
        }

        private PaintImage[] _images;

        public IReadOnlyList<PaintImage> GetImages()
        {
            return new ReadOnlyCollection<PaintImage>(_images);
        }
    }
}