using System;
using Global.Services.InputViews.Runtime;
using TMPro;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    [DisallowMultipleComponent]
    public class InputDebug : MonoBehaviour
    {
        [Inject]
        private void Construct(IInputView inputView)
        {
            _inputView = inputView;
        }

        [SerializeField] private TMP_Text _text;
        
        private IInputView _inputView;

        private void Update()
        {
            if (_inputView == null)
                return;
            
            _text.text = $"Is touched: {_inputView.IsLeftMouseButtonPressed}\n " +
                         $"World: {_inputView.ScreenToWorld()}\n " +
                         $"Position: {_inputView.Position}\n " +
                         $"Touches: {Input.touches.Length}\n" +
                         $"Is mobile: {Application.isMobilePlatform}";
        }
    }
}