using Datas;
using UnityEngine;


namespace Services
{
    public class GameInizializator : MonoBehaviour
    {
        [SerializeField] private SnakeData _data;
        private ScoreFabric _scoreFabric = new ScoreFabric();
        private void Start()
        {
            var fabric = new SnakeFabric();
            var snakeController = fabric.Construct(_data.Struct, Vector2.zero);
            var inputer = new InputService(this);
            inputer.AddToObserver(snakeController);
            CreateScore();
        }

        public void CreateScore()
        {
            var score = _scoreFabric.Construct();
            score.DestroyPoint += CreateScore;
        }
    }
}