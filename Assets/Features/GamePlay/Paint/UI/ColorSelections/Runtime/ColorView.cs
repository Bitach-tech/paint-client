using System;
using DG.Tweening;
using GamePlay.Paint.Tools.Common.Definition;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Paint.UI.ColorSelections.Runtime
{
    [DisallowMultipleComponent]
    public class ColorView : MonoBehaviour
    {
        [SerializeField] private ColorDefinition _color;
        [SerializeField] private ColorViewToolsDictionary _tools;
        [SerializeField] private Button _button;
        
        public ColorDefinition Color => _color;
        
        public event Action<ColorView> Selected;

        private void Awake()
        {
            foreach (var tool in _tools)
                tool.Value.color = _color.Color;
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
            transform.DOScale(Vector3.one, 0.3f);
        }
        
        public void OnToolChanged(ToolType tool)
        {
            foreach (var (_, view) in _tools)
                view.gameObject.SetActive(false);

            _tools[tool].gameObject.SetActive(true);
        }
        
        private void OnClicked()
        {
            transform.DOScale(Vector3.one * 1.1f, 0.3f);
            
            Selected?.Invoke(this);
        }
    }
}