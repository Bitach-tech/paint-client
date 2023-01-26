using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Menu.Runtime;
using GamePlay.Paint.ImageStorage.Runtime;
using GamePlay.Paint.Loop.Runtime;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Events;
using GamePlay.Services.LevelLoops.Logs;
using Global.Services.CurrentCameras.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Services.LevelLoops.Runtime
{
    [DisallowMultipleComponent]
    public class LevelLoop :
        MonoBehaviour,
        ILocalLoadListener,
        ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            ICurrentCamera currentCamera,
            ILevelCamera levelCamera,
            IMenuUI menuUI,
            IPaintLoop paintLoop,
            IAds ads,
            LevelLoopLogger logger)
        {
            _paintLoop = paintLoop;
            _ads = ads;
            _menuUI = menuUI;
            _logger = logger;
            _currentCamera = currentCamera;
            _levelCamera = levelCamera;
        }

        private IAds _ads;

        private ICurrentCamera _currentCamera;
        private ILevelCamera _levelCamera;

        private LevelLoopLogger _logger;

        private IMenuUI _menuUI;

        private IDisposable _playClickListener;
        private IPaintLoop _paintLoop;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _playClickListener = Msg.Listen<PlayClickEvent>(OnPlayClicked);
        }

        public void OnDisabled()
        {
            _playClickListener?.Dispose();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            StartGame(data.Image);
        }

        private void StartGame(PaintImage image)
        {
            Msg.Publish(new GameStartEvent());

            _ads.ShowInterstitial();
            _paintLoop.Open(image);
        }
    }
}