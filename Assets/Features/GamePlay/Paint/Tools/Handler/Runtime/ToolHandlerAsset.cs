using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Paint.Tools.Handler.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "ToolHandler",
        menuName = GamePlayAssetsPaths.ToolHandler + "Service")]
    public class ToolHandlerAsset : LocalServiceAsset
    {
        [SerializeField] private ToolHandler _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var tool = Instantiate(_prefab);
            tool.name = "ToolHandler";

            builder.RegisterComponent(tool)
                .AsCallbackListener();

            serviceBinder.AddToModules(tool);
        }
    }
}