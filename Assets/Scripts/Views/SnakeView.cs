using System;
using System.Collections;
using Interfaces;
using Services;
using UnityEngine;


namespace Views
{ 
    [RequireComponent(typeof(Rigidbody2D))]
    internal class SnakeView : MonoBehaviour, IView
    {
        private IViewModel _model;

        public event Action<GameObject> TriggerAction = delegate(GameObject o) {  };

        public void Initialize(IViewModel model)
        {
            _model = model;
        }

        public void OnPickupScore()
        {
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            foreach (var child in gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                var currentColor = child.color;
                child.color = Color.green;
                yield return new WaitForSeconds(Time.deltaTime * 2);
                child.color = currentColor;
            }

            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            TriggerAction.Invoke(other.gameObject);
        }
    }
}