using System;
using UnityEngine;

namespace GamePlay.Paint.Canvases.Runtime.Lines
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(LineRenderer))]
    public class Line : MonoBehaviour, ILine
    {
        [SerializeField] private float _alpha;
        [SerializeField] private bool _applyColorToMaterial;
        [SerializeField] private LineRenderer _renderer;

        private Vector3[] _positions;

        public void Construct(Vector2 position, float width, Color color, int order)
        {
            color.a = _alpha;
            _positions = new Vector3[] { position };
            _renderer.SetPositions(_positions);

            _renderer.widthMultiplier = width;
            _renderer.startColor = color;
            _renderer.endColor = color;
            _renderer.sortingOrder = order;

            if (_applyColorToMaterial == true)
            {
                _renderer.material.color = color;
                _renderer.material.SetFloat("_Stencil", order);
            }
        }

        public void AddPoint(Vector2 point)
        {
            Array.Resize(ref _positions, _positions.Length + 1);
            _positions[^1] = point;
            _renderer.positionCount = _positions.Length;
            _renderer.SetPositions(_positions);
        }
    }
}