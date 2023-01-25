using System.Collections.Generic;
using GamePlay.Common.Paths;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    [CreateAssetMenu(fileName = "Config_LineWidth",
        menuName = GamePlayAssetsPaths.LineFactory + "Config")]
    public class LineWidthConfigAsset : ScriptableObject
    {
        [SerializeField] private LineWidthDictionary _widths;

        public IReadOnlyDictionary<LineWidth, float> Widths => _widths;
    }
}