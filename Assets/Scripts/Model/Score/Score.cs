using System;
using Model.Enemies;

namespace Model.Score
{
    public class Score : Transformable
    {
        public int Value { get; private set; }

        public event Action<int> ScoreChanged;

        public void OnEnemyDied()
        {
            Value += Config.GolemAward;
            ScoreChanged?.Invoke(Value);
        }
    }
}