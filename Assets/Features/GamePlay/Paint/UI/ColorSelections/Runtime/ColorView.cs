using System;
using DG.Tweening;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ColorView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private ColorViewToolsDictionary _tools;
        [SerializeField] private Button _button;

        private ColorDefinition _color;
        private bool _isLocked;
        
        public ColorDefinition Color => _color;

        public event Action<ColorView> Selected;

        public void Construct(ColorDefinition color)
        {
            _color = color;

            foreach (var (_, view) in _tools)
            {
                view.Construct(_color.Color);
                view.Disable();
            }
        }
        
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
            _isLocked = false;

            transform.DOScale(Vector3.one, 0.2f);
        }

        public void OnToolChanged(ToolType tool)
        {
            foreach (var (_, view) in _tools)
                view.Disable();

            _tools[tool].Enable();
        }

        private void OnClicked()
        {
            _isLocked = true;
            transform.DOScale(Vector3.one * 1.2f, 0.2f);

            Selected?.Invoke(this);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;
            
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one * 1.1f, 0.2f));
            sequence.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_isLocked == true)
                return;

            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(1f, 0.2f));
            sequence.Play();
        }
    }
}