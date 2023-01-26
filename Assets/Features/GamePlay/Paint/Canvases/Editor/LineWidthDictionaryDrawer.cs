using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Paint.Canvases.Runtime;
using GamePlay.Paint.Canvases.Runtime.Lines;
using UnityEditor;

namespace GamePlay.Paint.Canvases.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LineWidthDictionary))]
    public class LineWidthDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}