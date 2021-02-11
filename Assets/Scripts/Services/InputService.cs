using System;
using System.Collections;
using Enums;
using Interfaces;
using UnityEngine;


namespace Services
{
    public class InputService
    {
        private Action<Rotate> Moving = delegate(Rotate rotate) {  };
        private string _verticalAxis = "Vertical";
        private string _horizontalAxis = "Horizontal";

        public InputService(MonoBehaviour behaviour)
        {
            behaviour.StartCoroutine(Update());
        }

        public void AddToObserver(IMoving moving)
        {
            Moving += moving.Move;
        }
        
        private IEnumerator Update()
        {
            while (true)
            {
                Rotate rotate;
                if (Input.GetAxis(_verticalAxis) > 0)
                {
                    rotate = Rotate.Up;
                    Moving.Invoke(rotate);
                }
                else if (Input.GetAxis(_verticalAxis) < 0)
                {
                    rotate = Rotate.Back;
                    Moving.Invoke(rotate);
                }
                else if (Input.GetAxis(_horizontalAxis) > 0)
                {
                    rotate = Rotate.Right;
                    Moving.Invoke(rotate);
                }
                else if (Input.GetAxis(_horizontalAxis) < 0)
                {
                    rotate = Rotate.Left;
                    Moving.Invoke(rotate);
                }
                
                yield return new WaitForEndOfFrame();
            }
        }
    }
}