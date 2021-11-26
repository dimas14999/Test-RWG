using UI.ScoreUI;
using UnityEngine;
using Gameplay.Spaceships;
using UI.HealthUI;

namespace UI.Logic
{
    //Класс отвечающий за логику в UI
    public class UILogic : MonoBehaviour
    {
        [SerializeField] private Score _scoreUI;
        [SerializeField] private Health _healthUI;
        //[SerializeField] private

        private int _score;
        private int _health;

        private void OnEnable() 
        {
            Enemy.EnemyDead += OnEnemyIsDied;
            Player.PlayerDead += OnPlayerDied;         
        }

        public void AddScore(int score)
        {
            _score += score;
            _scoreUI.AddScore(_score);
        }

        public void OnPlayerDied(int health)
        {
            _healthUI.OutputHealth(health);
        }
        public void OnEnemyIsDied(int score)
        {
            AddScore(score);
        }
        private void OnDisable()
        {
            Enemy.EnemyDead -= OnEnemyIsDied;
            Player.PlayerDead -= OnPlayerDied;
        }
    }
}
