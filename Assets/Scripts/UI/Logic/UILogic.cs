using UI.ScoreUI;
using UnityEngine;
using Gameplay.Spaceships;
using UI.HealthUI;
using UI.EnergyUI;

namespace UI.Logic
{
    //Класс отвечающий за логику в UI
    public class UILogic : MonoBehaviour

    {

        [SerializeField] private Score _scoreUI;
        [SerializeField] private Health _healthUI;
        [SerializeField] private Energy _energyUI;

        private int _score;
        private float _energy;

        private void OnEnable() 
        {
            Enemy.EnemyDead += OnEnemyIsDied;
            Player.HealthDamage += OnPlayerDied;
            Player.PlayerEnergy += OnAddEnergy;
        }

        public void AddScore(int score)
        {
            _score += score;
            _scoreUI.AddScore(_score);
        }

        public void OnAddEnergy(float energy)
        {
            _energyUI.OutputEnergy(energy);
        }
        public void OnPlayerDied(float health)
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
            Player.HealthDamage -= OnPlayerDied;
            Player.PlayerEnergy -= OnAddEnergy;
        }
    }
}
