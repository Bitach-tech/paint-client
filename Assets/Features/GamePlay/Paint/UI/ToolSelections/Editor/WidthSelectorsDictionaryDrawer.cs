using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using UnityEditor;

namespace GamePlay.Paint.UI.ToolSelections.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(WidthSelectorsDictionary))]
    public class WidthSelectorsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}