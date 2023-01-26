using GamePlay.Paint.Canvases.Runtime;
using GamePlay.Paint.Canvases.Runtime.Borders;
using GamePlay.Paint.Canvases.Runtime.Lines;
using GamePlay.Paint.Tools.Implementation.Abstract;
using Global.Services.InputViews.Runtime;
using Global.Services.Updaters.Runtime.Abstract;
using UnityEngine;

namespace GamePlay.Paint.Tools.Implementation.Brush.Runtime
{
    public class Brush : ITool, IFixedUpdatable
    {
        public Brush(
            IUpdater updater,
            IInputView input,
            ILineFactory factory,
            IPaintCanvasBorders borders,
            LineData data)
        {
            _borders = borders;
            _updater = updater;
            _input = input;
            _factory = factory;
            _data = data;
        }

        private readonly IUpdater _updater;
        private readonly IInputView _input;
        private readonly ILineFactory _factory;
        private readonly LineData _data;

        private ILine _current;
        private IPaintCanvasBorders _borders;

        public void Enable()
        {
            _updater.Add(this);
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void OnFixedUpdate(float delta)
        {
            if (_input.IsLeftMouseButtonPressed == false)
            {
                _current = null;
                return;
            }
            
            var position = _input.ScreenToWorld();
            
            if (_borders.IsInBorders(position) == false)
                return;

            if (_current == null)
                _current = _factory.Create(position, _data.Tool, _data.Width, _data.Color);
            else
                _current.AddPoint(position);
        }
    }
}