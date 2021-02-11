using UnityEngine;

namespace Interfaces
{
    internal interface IModel
    {
        float Speed { get; }
        Transform[] Pieces { get; }

        void AddingNewPiece();
    }
}