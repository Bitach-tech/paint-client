using Global.Services.MessageBrokers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ToolSelectionUI : MonoBehaviour, IUiState, IToolSelectionUI
    {
        [Inject]
        private void Construct(IUiStateMachine uiStateMachine, UiConstraints constraints)
        {
            _constraints = constraints;
            _uiStateMachine = uiStateMachine;
        }

        [SerializeField] private GameObject _body;
        [SerializeField] private ToolView[] _views;

        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        private ToolView _current;

        public UiConstraints Constraints => _constraints;
        public string Name => "ToolSelection";

        private void OnEnable()
        {
            foreach (var view in _views)
                view.Selected += OnToolSelected;
        }

        private void OnDisable()
        {
            foreach (var view in _views)
                view.Selected -= OnToolSelected;
        }

        public void Open()
        {
            _uiStateMachine.EnterAsStack(this);
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        private void OnToolSelected(ToolView tool)
        {
            if (_current == null)
            {
                _current = tool;
                return;
            }

            if (_current == tool)
                return;

            _current.Deselect();
            _current = tool;

            Msg.Publish(new ToolSelectEvent(tool.Type));
        }
    }
}