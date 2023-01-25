using GamePlay.Common.Paths;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Paint.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "PaintImage",
        menuName = GamePlayAssetsPaths.ImageStorage + "Image")]
    public class PaintImage : ScriptableObject
    {
        [SerializeField] private Sprite _image;

        public Sprite Image => _image;
    }
}