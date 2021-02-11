using System;
using Interfaces;
using UnityEngine;


namespace Markers
{
    public class PointMarker : MonoBehaviour, IScore
    {
        private int _pointCount = 1;

        public Action DestroyPoint { get; set; } = delegate {  };
        public int PointCount => _pointCount;
        
        public void SetPointCount(int count)
        {
            _pointCount = count;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            DestroyPoint?.Invoke();
            DestroyPoint = null;
            Destroy(gameObject);
        }
    }
}