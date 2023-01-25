using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using UnityEngine;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "ColorSelection",
        menuName = GamePlayAssetsPaths.ColorSelection + "Service")]
    public class ColorSelectionUiAsset : LocalServiceAsset
    {
        [SerializeField] [Scene] private string _scene;
        
        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<ColorSelectionUI>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);
            var root = loadResult.Searched;

            builder.RegisterComponent(root)
                .As<IColorSelectionUI>();
        }
    }
}