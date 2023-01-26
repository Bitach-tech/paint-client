using DG.Tweening;
using GamePlay.Paint.Tools.Common.Definition;
using Global.Services.MessageBrokers.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    [DisallowMultipleComponent]
    public class WidthSelection : MonoBehaviour
    {
        [SerializeField] private WidthSelectorsDictionary _selectors;

        private Button _current;

        private void OnEnable()
        {
            foreach (var (width, button) in _selectors)
            {
                void Callback()
                {
                    OnWidthSelected(width);
                }

                button.onClick.AddListener(Callback);
            }
        }

        private void OnDisable()
        {
            foreach (var (_, button) in _selectors)
                button.onClick.RemoveAllListeners();
        }

        private void OnWidthSelected(LineWidth width)
        {
            if (_current == _selectors[width])
                return;

            if (_current != null)
                _current.transform.DOScale(Vector3.one, 0.3f);
            
            _selectors[width].transform.DOScale(Vector3.one * 1.1f, 0.3f);

            _current = _selectors[width];

            Msg.Publish(new WidthSelectEvent(width));
        }
    }
}