using System.Collections.Generic;
using Common.Local.ComposedSceneConfig;
using Common.Local.Services.Abstract;
using GamePlay.Common.Paths;
using GamePlay.Menu.Runtime;
using GamePlay.Paint.Canvases.Runtime;
using GamePlay.Paint.ImageStorage.Runtime;
using GamePlay.Paint.Loop.Runtime;
using GamePlay.Paint.Tools.Handler.Runtime;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using GamePlay.Services.Background.Runtime;
using GamePlay.Services.Common.Scope;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Runtime;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer.Unity;

namespace GamePlay.Config.Services.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = "Level", menuName = GamePlayAssetsPaths.Root + "Scene")]
    public class GameAsset : ComposedSceneAsset
    {
        [SerializeField] private LevelCameraAsset _levelCamera;
        [SerializeField] private LevelLoopAsset _levelLoop;
        [SerializeField] private MenuUIAsset _menuUi;
        [SerializeField] private GameBackgroundAsset _background;
        [SerializeField] private ToolHandlerAsset _toolHandler;
        [SerializeField] private PaintCanvasAsset _canvas;
        [SerializeField] private ColorSelectionUiAsset _colorSelectionUI;
        [SerializeField] private ToolSelectionUiAsset _toolSelectionUI;
        [SerializeField] private ImageStorageAsset _imageStorage;
        [SerializeField] private PaintLoopAsset _paintLoop;

        [SerializeField] private LevelScope _scopePrefab;

        protected override LocalServiceAsset[] AssignServices()
        {
            var list = new List<LocalServiceAsset>
            {
                _levelCamera,
                _levelLoop,
                _menuUi,
                _background,
                _toolHandler,
                _canvas,
                _colorSelectionUI,
                _toolSelectionUI,
                _imageStorage,
                _paintLoop
            };

            return list.ToArray();
        }

        protected override LifetimeScope AssignScope()
        {
            return _scopePrefab;
        }
    }
}