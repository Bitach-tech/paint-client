using System;
using System.Collections.Generic;
using System.Linq;
using Common.Local.Services.Abstract.Callbacks;
using DG.Tweening;
using GamePlay.Paint.Tools.Common.Definition;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ColorSelectionUI : MonoBehaviour, IUiState, IColorSelectionUI, ILocalSwitchListener,
        ILocalAwakeListener
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

        [SerializeField] private float _cellHeight;
        [SerializeField] private ColorDefinition[] _colors;
        [SerializeField] private ColorView _viewPrefab;
        [SerializeField] private RectTransform _viewsRoot;

        private ColorView _current;

        private IUiStateMachine _uiStateMachine;
        private UiConstraints _constraints;

        private IDisposable _toolSelectListener;

        private readonly List<ColorView> _views = new();

        public UiConstraints Constraints => _constraints;
        public string Name => "ColorSelection";

        public void OnAwake()
        {
            foreach (var color in _colors)
            {
                var view = Instantiate(_viewPrefab, _viewsRoot);
                view.Construct(color);

                _views.Add(view);
            }

            _viewsRoot.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _views.Count * _cellHeight);

            _body.SetActive(false);
        }

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
                _current.transform.DOScale(Vector3.one * 1.1f, 0.1f);
                Msg.Publish(new ColorSelectEvent(color.Color));
                
                return;
            }

            if (_current == color)
                return;

            _current.transform.DOScale(Vector3.one, 0.1f);
            color.transform.DOScale(Vector3.one * 1.1f, 0.1f);
            
            _current.Deselect();
            _current = color;

            Msg.Publish(new ColorSelectEvent(color.Color));
        }

        private void OnToolSelected(ToolSelectEvent data)
        {
            if (_current == null)
            {
                OnColorSelected(_views.First());
            }
            
            switch (data.Tool)
            {
                case ToolType.Brush:
                    _body.SetActive(true);
                    break;
                case ToolType.Pen:
                    _body.SetActive(true);
                    break;
                case ToolType.Marker:
                    _body.SetActive(true);
                    break;
                case ToolType.Eraser:
                    _body.SetActive(false);
                    break;
                case ToolType.Sticker:
                    _body.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var view in _views)
                view.OnToolChanged(data.Tool);
        }
    }
}