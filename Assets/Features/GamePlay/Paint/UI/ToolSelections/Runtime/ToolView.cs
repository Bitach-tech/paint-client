using System;
using DG.Tweening;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Paint.UI.ToolSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ToolView : MonoBehaviour
    {
        [SerializeField] private ToolType _type;

        [SerializeField] private Button _button;

        public ToolType Type => _type;

        public event Action<ToolView> Selected;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void Deselect()
        {
            transform.DOScale(Vector3.one, 0.3f);
        }

        private void OnClicked()
        {
            transform.DOScale(Vector3.one * 1.1f, 0.3f);

            Selected?.Invoke(this);
        }
    }
}