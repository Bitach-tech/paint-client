using GamePlay.Canvases.Runtime;
using GamePlay.Paint.Tools.Implementation.Abstract;
using Global.Services.InputViews.Runtime;
using Global.Services.Updaters.Runtime.Abstract;

namespace GamePlay.Paint.Tools.Implementation.Brush.Runtime
{
    public class Brush : ITool, IFixedUpdatable
    {
        public Brush(
            IUpdater updater,
            IInputView input,
            ILineFactory factory,
            LineData data)
        {
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

        public void Enable(ILine line)
        {
            _updater.Add(this);
        }

        public void Disable()
        {
            _updater.Remove(this);
        }

        public void OnFixedUpdate(float delta)
        {
            var position = _input.ScreenToWorld();
            
            
        }
    }
}