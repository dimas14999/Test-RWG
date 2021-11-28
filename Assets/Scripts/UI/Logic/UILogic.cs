using UI.ScoreUI;
using UnityEngine;
using Gameplay.Spaceships;
using UI.HealthUI;
using UI.EnergyUI;
using DG.Tweening;

namespace UI.Logic
{
    //The class responsible for the logic in the UI
    public class UILogic : MonoBehaviour

    {

        [SerializeField] private Score _scoreUI;
        [SerializeField] private Health _healthUI;
        [SerializeField] private Energy _energyUI;
        [SerializeField] private DeadScreen _deadScreen;

        private int _score;
        private float _energy;

        private void OnEnable() 
        {
            Enemy.EnemyDead += OnEnemyIsDied;
            Player.HealthDamage += OnPlayerDamage;
            Player.PlayerEnergy += OnAddEnergy;
            Player.PlayerDead += OnPlayerDead;
        }

        private void Start()
        {
            //Deactivating the defeat screen
            _deadScreen.gameObject.SetActive(false);
            _deadScreen.gameObject.transform.DOScale(Vector3.zero, 0f);
        }
        public void AddScore(int score)
        {
            //Adding a score for killing an enemy
            _score += score;
            _scoreUI.AddScore(_score);
            _deadScreen.Score(_score);
        }

        public void OnPlayerDead()
        {
            //Activating the defeat screen
            _deadScreen.gameObject.SetActive(true);
            _deadScreen.gameObject.transform.DOScale(Vector3.one, 1f);
        }

        //Displaying the rate of fire on the screen
        public void OnAddEnergy(float energy)
        {
            _energyUI.OutputEnergy(energy);
        }

        //Displaying lives on the screen
        public void OnPlayerDamage(float health)
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
            Player.HealthDamage -= OnPlayerDamage;
            Player.PlayerEnergy -= OnAddEnergy;
            Player.PlayerDead -= OnPlayerDead;
        }
    }
}
