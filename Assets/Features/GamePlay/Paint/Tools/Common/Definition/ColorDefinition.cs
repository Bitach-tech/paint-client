using GamePlay.Common.Paths;
using UnityEngine;

namespace GamePlay.Paint.Tools.Common.Definition
{
    [CreateAssetMenu(fileName = "Color_", menuName = GamePlayAssetsPaths.PaintConfig + "Color")]
    public class ColorDefinition : ScriptableObject
    {
        [SerializeField] private Color _color;

        public Color Color => _color;
    }
}