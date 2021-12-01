using UI.ScoreUI;
using UnityEngine;
using Gameplay.Spaceships;
using UI.HealthUI;
using UI.EnergyUI;
using DG.Tweening;

namespace UI.Logic
{
    public class UILogic : MonoBehaviour
    {

        [SerializeField] private DeadScreen _deadScreen;
        [SerializeField] private Health _healthUI;
        [SerializeField] private Energy _energyUI;
        [SerializeField] private Score _scoreUI;
        [SerializeField] private Player _player;

        private int _score = 0;

        private void OnEnable() 
        {
            _player.HealthDamage += OnPlayerDamage;
            _player.PlayerDead += OnPlayerDead;
        }

        private void Start()
        {
            _deadScreen.DisplayScore(0);
            _deadScreen.gameObject.SetActive(false);
            _deadScreen.gameObject.transform.DOScale(Vector3.zero, 0f);
        }

        public void AddScore(int score)
        {
            _score += score;
            _scoreUI.DisplayScore(_score);
            _deadScreen.DisplayScore(_score);
        }

        private void OnPlayerDead()
        {
            _deadScreen.gameObject.SetActive(true);
            _deadScreen.gameObject.transform.DOScale(Vector3.one, 1f);
        }

        public void AddEnergy(float energy)
        {
            _energyUI.DisplayEnergy(energy);
        }

        private void OnPlayerDamage(float health)
        {
            _healthUI.DisplayHealth(health);
        }

        private void OnDisable()
        {
            _player.HealthDamage -= OnPlayerDamage;
            _player.PlayerDead -= OnPlayerDead;
        }
    }
}
