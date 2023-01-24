using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Services.LevelCameras.Runtime;
using GamePlay.Services.LevelLoops.Events;
using GamePlay.Services.LevelLoops.Logs;
using GamePlay.Services.MenuUI.Runtime;
using Global.Services.CurrentCameras.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.ServiceSDK.Advertisment.Runtime;
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
            IAds ads,
            LevelLoopLogger logger)
        {
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
        private IDisposable _quizCompleteListener;
        private IDisposable _restartRequestListener;

        public void OnLoaded()
        {
            _currentCamera.SetCamera(_levelCamera.Camera);

            _logger.OnLoaded();

            _menuUI.Open();
        }

        public void OnEnabled()
        {
            _playClickListener = Msg.Listen<PlayClickEvent>(OnPlayClicked);
            _restartRequestListener = Msg.Listen<RestartRequestEvent>(OnRestartRequested);
        }

        public void OnDisabled()
        {
            _playClickListener?.Dispose();
            _quizCompleteListener?.Dispose();
            _restartRequestListener?.Dispose();
        }

        private void OnPlayClicked(PlayClickEvent data)
        {
            StartGame();
        }

        private void OnRestartRequested(RestartRequestEvent data)
        {
            StartGame();
        }

        private void StartGame()
        {
            Msg.Publish(new GameStartEvent());

            _ads.ShowInterstitial();
        }
    }
}