using System;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(LineRenderer))]
    public class Line : MonoBehaviour, ILine
    {
        [SerializeField] private LineRenderer _renderer;

        private Vector3[] _positions;

        public void Construct(Vector2 position, float width, Color color)
        {
            transform.position = position;
            _positions = new Vector3[] { position };
            _renderer.SetPositions(_positions);

            _renderer.widthMultiplier = width;
            _renderer.startColor = color;
            _renderer.endColor = color;
        }

        public void AddPoint(Vector2 point)
        {
            Array.Resize(ref _positions, _positions.Length + 1);
            _positions[^1] = point;
            _renderer.SetPositions(_positions);
        }
    }
}