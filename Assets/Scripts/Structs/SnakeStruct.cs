using System;
using UnityEngine;

namespace Structs
{
    [Serializable]
    internal struct SnakeStruct
    {
        public int BodyCount;
        [Range(0.0f, 1.0f)] public float Speed;
    }
}