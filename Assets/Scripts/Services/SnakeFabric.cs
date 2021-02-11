using Interfaces;
using Models;
using Structs;
using UnityEngine;
using ViewModels;
using Views;


namespace Services
{
    internal class SnakeFabric
    {
        public IViewModel Construct(SnakeStruct str, Vector2 positionForSpawn)
        {
            var snakeGo = new GameObject("Snake").AddComponent<SnakeView>();
            var snakeTransform = snakeGo.transform;
            snakeTransform.position = positionForSpawn;
            var model = new SnakeModel(str, snakeTransform);
            for (int i = 0; i < str.BodyCount; i++)
            {
                model.AddingNewPiece();
            }

            if (snakeGo.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
            {
                rigidbody2D.gravityScale = 0.0f;
            }

            return new SnakeViewModel(model, snakeGo, snakeGo.gameObject);
        }
    }
}