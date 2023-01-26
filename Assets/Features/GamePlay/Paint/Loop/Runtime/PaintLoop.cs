using GamePlay.Paint.Canvases.Runtime.View;
using GamePlay.Paint.ImageStorage.Runtime;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using GamePlay.Paint.UI.ToolSelections.Runtime;
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
            UiConstraints constraints)
        {
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

        public UiConstraints Constraints => _constraints;
        public string Name => "Paint";

        public void Open(PaintImage image)
        {
            _uiStateMachine.EnterAsSingle(this);
            _colorSelection.Open();
            _toolSelection.Open();
            _canvasView.Construct(image);
        }

        public void Recover()
        {
        }

        public void Exit()
        {
            _canvasView.Disable();
        }
    }
}