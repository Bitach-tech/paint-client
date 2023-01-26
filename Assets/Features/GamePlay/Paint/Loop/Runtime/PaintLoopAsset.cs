using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Runtime.Abstract;
using Global.Services.UiStateMachines.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Paint.Loop.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "PaintLoop",
        menuName = GamePlayAssetsPaths.PaintLoop + "Service")]
    public class PaintLoopAsset : LocalServiceAsset
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] private PaintLoop _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var loop = Instantiate(_prefab);
            loop.name = "PaintLoop";

            builder.RegisterComponent(loop)
                .WithParameter(_constraints)
                .As<IPaintLoop>();

            serviceBinder.AddToModules(loop);
        }
    }
}