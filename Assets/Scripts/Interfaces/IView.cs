using System;
using UnityEngine;

namespace Interfaces
{
    internal interface IView
    {

        event Action<GameObject> TriggerAction;
        void Initialize(IViewModel model);
        void OnPickupScore();
        void OnDestroySnake();
    }
}