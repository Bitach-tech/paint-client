using Global.Services.MessageBrokers.Runtime;
using Global.Services.UiStateMachines.Runtime;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace GamePlay.Services.MenuUI.Runtime
{
    [DisallowMultipleComponent]
    public class MenuUI : MonoBehaviour, IMenuUI, IUiState
    {
        [Inject]
        private void Construct(
            IUiStateMachine uiStateMachine,
            UiConstraints constraints)
        {
            _uiStateMachine = uiStateMachine;
            _constraints = constraints;
        }

        [SerializeField] private Button _playButton;
        [SerializeField] private GameObject _body;

        private UiConstraints _constraints;
        private IUiStateMachine _uiStateMachine;

        private void Awake()
        {
            _body.SetActive(false);
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
        }

        public void Open()
        {
            _uiStateMachine.EnterAsSingle(this);
            _body.SetActive(true);
        }

        public UiConstraints Constraints => _constraints;
        public string Name => "MainMenu";

        public void Recover()
        {
            _body.SetActive(true);
        }

        public void Exit()
        {
            _body.SetActive(false);
        }

        private void OnPlayClicked()
        {
            var clicked = new PlayClickEvent();
            Msg.Publish(clicked);
        }
    }
}