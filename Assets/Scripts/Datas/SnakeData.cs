using Structs;
using UnityEngine;


namespace Datas
{
    [CreateAssetMenu(menuName = "Datas/SnakeData")]
    internal class SnakeData : ScriptableObject
    {
        public SnakeStruct Struct;
        public Color Color;
    }
}