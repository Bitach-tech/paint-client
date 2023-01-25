using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Canvases.Runtime;
using UnityEditor;

namespace GamePlay.Canvases.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(LineWidthDictionary))]
    public class LineWidthDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}