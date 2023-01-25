using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Paint.Canvases.Runtime;
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