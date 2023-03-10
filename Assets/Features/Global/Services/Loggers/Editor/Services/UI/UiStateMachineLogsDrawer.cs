using Common.ReadOnlyDictionaries.Editor;
using Global.Services.UiStateMachines.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services.UI
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UiStateMachineLogs))]
    public class UiStateMachineLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}