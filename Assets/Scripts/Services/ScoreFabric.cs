using Interfaces;
using Markers;
using UnityEngine;

namespace Services
{
    public class ScoreFabric
    {
        public IScore Construct()
        {
            var pointMarker = new GameObject("point").AddComponent<PointMarker>();
            var camera = Camera.main;
            var resource = Resources.Load<Sprite>("Sprites/Circle");
            pointMarker.gameObject
                .SetSprite(resource)
                .SetBoxCollider2D(Vector2.zero, resource.bounds.size);
            var position = camera.ScreenToWorldPoint
            (new Vector2(
                Random.Range(0.0f, camera.pixelWidth),
                Random.Range(0.0f, camera.pixelHeight)));
            position.z = 0.0f;
            pointMarker.transform.position = position;
            return pointMarker;

        }

        public IScore ConstructWithPointCount(int pointCount)
        {
            var pointMarker = Construct();
            pointMarker.SetPointCount(pointCount);
            return pointMarker;
        }
    }
}