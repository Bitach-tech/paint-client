﻿using System;
using Common.Local.Services.Abstract.Callbacks;
using GamePlay.Paint.Canvases.Runtime.Borders;
using GamePlay.Paint.Canvases.Runtime.Lines;
using GamePlay.Paint.Tools.Common.Definition;
using GamePlay.Paint.Tools.Implementation.Abstract;
using GamePlay.Paint.Tools.Implementation.Brush.Runtime;
using GamePlay.Paint.UI.ColorSelections.Runtime;
using GamePlay.Paint.UI.ToolSelections.Runtime;
using Global.Services.InputViews.Runtime;
using Global.Services.MessageBrokers.Runtime;
using Global.Services.Updaters.Runtime.Abstract;
using UnityEngine;
using VContainer;

namespace GamePlay.Paint.Tools.Handler.Runtime
{
    [DisallowMultipleComponent]
    public class ToolHandler : MonoBehaviour, ILocalSwitchListener, ILocalAwakeListener
    {
        [Inject]
        private void Construct(
            IUpdater updater,
            IInputView input,
            ILineFactory factory,
            IPaintCanvasBorders borders)
        {
            _borders = borders;
            _factory = factory;
            _input = input;
            _updater = updater;
        }

        private readonly LineData _data = new();

        private IDisposable _toolSelectListener;
        private IDisposable _colorSelectListener;
        private IDisposable _widthSelectListener;

        private ITool _current;

        private Brush _pencil;
        private Brush _marker;
        private Brush _brush;
        private Brush _eraser;

        private Color _color;

        private IUpdater _updater;
        private IInputView _input;
        private ILineFactory _factory;
        private IPaintCanvasBorders _borders;

        public void OnAwake()
        {
            _pencil = new Brush(_updater, _input, _factory, _borders, _data);
            _marker = new Brush(_updater, _input, _factory, _borders, _data);
            _brush = new Brush(_updater, _input, _factory, _borders, _data);
            _eraser = new Brush(_updater, _input, _factory, _borders, _data);
        }

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
            _data.OnToolChanged(data.Tool);

            _current?.Disable();

            switch (data.Tool)
            {
                case ToolType.Brush:
                    _current = _brush;
                    _data.OnColorChanged(_color);
                    break;
                case ToolType.Pen:
                    _current = _pencil;
                    _data.OnColorChanged(_color);
                    break;
                case ToolType.Marker:
                    _current = _marker;
                    _data.OnColorChanged(_color);
                    break;
                case ToolType.Eraser:
                    _current = _eraser;
                    _data.OnColorChanged(Color.white);
                    break;
                case ToolType.Sticker:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _current?.Enable();
        }

        private void OnColorSelected(ColorSelectEvent data)
        {
            _data.OnColorChanged(data.Color.Color);
            _color = data.Color.Color;
        }

        private void OnWidthSelected(WidthSelectEvent data)
        {
            _data.OnWidthChanged(data.Width);
        }
    }
}