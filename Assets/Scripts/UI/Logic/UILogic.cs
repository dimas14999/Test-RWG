using UI.ScoreUI;
using UnityEngine;
using Gameplay.Spaceships;

namespace UI.Logic
{
    //Класс отвечающий за логику в UI
    public class UILogic : MonoBehaviour
    {
        [SerializeField] private Score _scoreUI;

        private int _score;

        private void OnEnable() 
        {
            Enemy.EnemyDead += OnEnemyIsDied;
        }

        public void AddScore(int score)
        {
            _score += score;
            _scoreUI.AddScore(_score);
        }

        public void OnEnemyIsDied(int score)
        {
            AddScore(score);
        }
        private void OnDisable()
        {
            Enemy.EnemyDead += OnEnemyIsDied;
        }
    }
}
