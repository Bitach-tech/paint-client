using Common.ReadOnlyDictionaries.Editor;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using UnityEditor;

namespace GamePlay.Paint.UI.ColorSelections.Editor
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(ColorViewToolsDictionary))]
    public class ColorViewToolsDictionaryDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}