using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Markers;
using Services;
using Structs;
using UnityEngine;
using Views;


namespace Models
{
    internal class SnakeModel : IModel
    {
        private readonly SnakeStruct _struct;
        private readonly Transform _parent;
        private readonly List<Transform> _pieces = new List<Transform>();

        public float Speed => _struct.Speed;
        public Transform[] Pieces => _pieces.ToArray();

        public Transform Head => _pieces.FirstOrDefault();

        public SnakeModel(SnakeStruct str, Transform parent)
        {
            _struct = str;
            _parent = parent;
        }
        
        public void AddingNewPiece()
        {
            var art = Resources.Load<Sprite>("Sprites/Circle");
            string name;
            var last = _pieces.LastOrDefault();
            Vector2 lastPiecePosition;
            if (last == null)
            {
                name = "head";
                lastPiecePosition = Vector2.zero;
            }

            else
            {
                name = "piece";
                lastPiecePosition = last.position;
            }
            var piece = new GameObject(name).transform;
            piece.parent = _parent;
            piece.localPosition = lastPiecePosition - new Vector2(0.0f, art.bounds.size.y);
            piece.gameObject
                .SetSprite(art)
                .SetCircleCollider2D(Vector2.zero, art.bounds.size.x / 2);
            _pieces.Add(piece);
        }


    }
}