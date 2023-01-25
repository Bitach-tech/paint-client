﻿using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using Global.Services.ScenesFlow.Handling.Data;
using Global.Services.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "PaintCanvas",
        menuName = GamePlayAssetsPaths.PaintCanvas + "Service")]
    public class PaintCanvasAsset : LocalServiceAsset
    {
        [SerializeField] [Scene] private string _scene;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<PaintCanvasRoot>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);
            var root = loadResult.Searched;

            builder.RegisterComponent(root.LineFactory)
                .As<ILineFactory>();
        }
    }
}