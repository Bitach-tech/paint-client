using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ColorSelectionUI : MonoBehaviour, IUiState, IColorSelectionUI, ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            UiConstraints constraints)
        {
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        [SerializeField] private GameObject _body;

        [SerializeField] private ColorView[] _views;
        
        private ColorView _current;
        
        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        private IDisposable _toolSelectListener;

        public UiConstraints Constraints => _constraints;
        public string Name => "ColorSelection";

        public void OnEnabled()
        {
            foreach (var view in _views)
                view.Selected += OnColorSelected;

            _toolSelectListener = Msg.Listen<ToolSelectEvent>(OnToolSelected);
        }

        public void OnDisabled()
        {
            foreach (var view in _views)
                view.Selected -= OnColorSelected;
            
            _toolSelectListener?.Dispose();
        }

        public void Open()
        {
            _uiStateMachine.EnterAsStack(this);
            _body.SetActive(true);
        }

        public void Close()
        {
            _uiStateMachine.Exit(this);
        }

        public void Exit()
        {
            _body.SetActive(false); 
        }
        
        public void Recover()
        {
            _body.SetActive(true);
        }
        
        private void OnColorSelected(ColorView color)
        {
            if (_current == null)
            {
                _current = color;
                return;
            }

            if (_current == color)
                return;

            _current.Deselect();
            _current = color;
            
            Msg.Publish(new ColorSelectEvent(color.Color));
        }

        private void OnToolSelected(ToolSelectEvent data)
        {
            foreach (var view in _views)
                view.OnToolChanged(data.Tool);
        }
    }
}