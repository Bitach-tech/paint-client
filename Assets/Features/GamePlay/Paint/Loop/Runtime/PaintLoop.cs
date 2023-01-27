using System.Collections;
using GamePlay.Paint.Canvases.Runtime.View;
using GamePlay.Paint.ImageStorage.Runtime;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using Global.Services.ServiceSDK.Advertisment.Abstract;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.Loop.Runtime
{
    [DisallowMultipleComponent]
    public class PaintLoop : MonoBehaviour, IUiState, IPaintLoop
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            IColorSelectionUI colorSelection,
            IToolSelectionUI toolSelection,
            IPaintCanvasView canvasView,
            IAds ads,
            UiConstraints constraints)
        {
            _ads = ads;
            _canvasView = canvasView;
            _uiStateMachine = uiStateMachine;
            _toolSelection = toolSelection;
            _colorSelection = colorSelection;
            _constraints = constraints;
        }

        private IColorSelectionUI _colorSelection;
        private IToolSelectionUI _toolSelection;

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;
        private IPaintCanvasView _canvasView;
        private IAds _ads;

        private readonly WaitForSeconds _wait = new(180f);

        public UiConstraints Constraints => _constraints;
        public string Name => "Paint";

        public void Open(PaintImage image)
        {
            _uiStateMachine.EnterAsSingle(this);
            _colorSelection.Open();
            _toolSelection.Open();
            _canvasView.Construct(image);
            StartCoroutine(ShowAd());
        }

        public void Recover()
        {
        }

        public void Exit()
        {
            StopAllCoroutines();
            _canvasView.Disable();
        }

        private IEnumerator ShowAd()
        {
            while (gameObject.activeSelf == true)
            {
                yield return _wait;
                
                _ads.ShowInterstitial();
            }
        }
    }
}