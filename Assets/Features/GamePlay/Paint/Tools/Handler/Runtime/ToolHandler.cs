using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Paint.Tools.Common.Definition;
using GamePlay.Paint.Tools.Implementation.Abstract;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using Global.Services.MessageBrokers.Runtime;
using UnityEngine;

namespace GamePlay.Paint.Tools.Handler.Runtime
{
    [DisallowMultipleComponent]
    public class ToolHandler : MonoBehaviour, ILocalSwitchListener
    {
        private IDisposable _toolSelectListener;
        private IDisposable _colorSelectListener;
        private IDisposable _widthSelectListener;

        private LineWidth _width;
        private ToolType _tool;
        private ColorDefinition _color;

        private readonly LineData _lineData;

        public void OnEnabled()
        {
            _toolSelectListener = Msg.Listen<ToolSelectEvent>(OnToolSelected);
            _colorSelectListener = Msg.Listen<ColorSelectEvent>(OnColorSelected);
            _widthSelectListener = Msg.Listen<WidthSelectEvent>(OnWidthSelected);
        }

        public void OnDisabled()
        {
            _toolSelectListener?.Dispose();
            _colorSelectListener?.Dispose();
            _widthSelectListener?.Dispose();
        }

        private void OnToolSelected(ToolSelectEvent data)
        {
            _tool = data.Tool;
            _lineData.OnToolChanged(data.Tool);
        }

        private void OnColorSelected(ColorSelectEvent data)
        {
            _color = data.Color;
            _lineData.OnColorChanged(data.Color);
        }

        private void OnWidthSelected(WidthSelectEvent data)
        {
            _width = data.Width;
            _lineData.OnWidthChanged(data.Width);
        }
    }
}