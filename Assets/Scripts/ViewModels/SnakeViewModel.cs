using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using Interfaces;
using Markers;
using UnityEngine;


namespace ViewModels
{
    internal class SnakeViewModel : IViewModel
    {
        private IModel _model;
        private IView _view;
        private Dictionary<Rotate, Vector3> _rotates;
        private Camera _main;
        private Vector3 _currentMove;
        private bool _isGame = true;


        public SnakeViewModel(IModel model, IView view, GameObject gameObject)
        {
            _model = model;
            _view = view;
            _view.TriggerAction += OnTrigger;
            _rotates = new Dictionary<Rotate, Vector3>()
            {
                {Rotate.Left, Vector3.left},
                {Rotate.Right, Vector3.right},
                {Rotate.Up, Vector3.up},
                {Rotate.Back, Vector3.down}
            };
            _main = Camera.main;
            gameObject.TryGetComponent(out MonoBehaviour behaviour);
            behaviour.StartCoroutine(UpdateMove());
        }
    
        private IEnumerator UpdateMove()
        {
            while (true)
            {
                if (_currentMove != Vector3.zero)
                {
                    var pieces = _model.Pieces;
                    var lastPosition = pieces[0].position;
                    pieces[0].position += _currentMove / 10 * _model.Speed;
                    
                    for (int i = 1; i < pieces.Length; i++)
                    {
                        var temp = pieces[i].position;
                        pieces[i].position = lastPosition;
                        lastPosition = temp;
                    }

                    var zeroScreenPoint = _main.ScreenToWorldPoint(Vector2.zero);
                    var maxScreenPoint = _main.ScreenToWorldPoint(new Vector2(_main.pixelWidth, _main.pixelHeight));
                    if (pieces[0].position.x < zeroScreenPoint.x)
                    {
                        pieces[0].position = new Vector2(maxScreenPoint.x, pieces[0].position.y);
                    }
                    else if (pieces[0].position.x > maxScreenPoint.x)
                    {
                        pieces[0].position = new Vector2(zeroScreenPoint.x, pieces[0].position.y);
                    }

                    if (pieces[0].position.y < zeroScreenPoint.y)
                    {
                        pieces[0].position = new Vector2(pieces[0].position.x, maxScreenPoint.y);
                    }
                    else if (pieces[0].position.y > maxScreenPoint.y)
                    {
                        pieces[0].position = new Vector2(pieces[0].position.x, zeroScreenPoint.y);
                    }
                }
                CheckOnCrash();
                yield return new WaitForSeconds(Time.deltaTime);
            }
            yield break;
        }

        public void CheckOnCrash()
        {
            var head = _model.Pieces[0];
            for (int i = 1; i < _model.Pieces.Length; i++)
            {
                if (_model.Pieces[i].position == head.position)
                {
                    _currentMove = Vector3.zero;
                    _isGame = false;
                    _view.OnDestroySnake();
                }
            }
        }
        
        public void Move(Rotate rotate)
        {
            if(_currentMove != -_rotates[rotate] && _isGame)
                _currentMove = _rotates[rotate];
        }

        private void OnTrigger(GameObject gameObject)
        {
            if (gameObject.TryGetComponent<IScore>(out var point))
            {
                _model.AddingNewPiece();
                _view.OnPickupScore();
            }
        }
    }
}