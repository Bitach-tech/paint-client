using System.Collections.Generic;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Paint.ImageStorage.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using VContainer;

namespace GamePlay.Menu.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUI : MonoBehaviour, IMenuUI, IUiState, ILocalAwakeListener, ILocalSwitchListener
    {
        [Inject]
        private void Construct(
            IImageStorage storage,
            IUiStateMachine uiStateMachine,
            UiConstraints constraints)
        {
            _storage = storage;
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        [SerializeField] private PaintImageSelector _selectorPrefab;
        [SerializeField] private GameObject _body;
        [SerializeField] private Transform _selectorsRoot;

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;
        private IImageStorage _storage;

        private readonly List<PaintImageSelector> _selectors = new();

        public UiConstraints Constraints => _constraints;
        public string Name => "MainMenu";

        public void OnAwake()
        {
            _body.SetActive(false);

            var images = _storage.GetImages();

            foreach (var image in images)
            {
                var selector = Instantiate(_selectorPrefab, _selectorsRoot);
                selector.Construct(image);
                _selectors.Add(selector);
            }
        }

        public void OnEnabled()
        {
            foreach (var selector in _selectors)
                selector.Selected += OnSelected;
        }

        public void OnDisabled()
        {
            foreach (var selector in _selectors)
                selector.Selected -= OnSelected;
        }

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
            _body.SetActive(true);
        }

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        private void OnSelected(PaintImage image)
        {
            var clicked = new PlayClickEvent(image);
            Msg.Publish(clicked);
        }
    }
}