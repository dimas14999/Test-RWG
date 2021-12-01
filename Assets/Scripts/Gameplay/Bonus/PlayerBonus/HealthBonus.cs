using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;


// Class for receiving health bonuses
public class HealthBonus : MonoBehaviour, IBonus
{

    [SerializeField] private float _health = 10;

    [SerializeField] private MovementSystem _movementSystem;

    private Spaceship _player;
    private void Update()
    {
        _movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    // Player collision check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player = collision.gameObject.GetComponent<Spaceship>();

        if (_player != null && _player.BattleIdentity == UnitBattleIdentity.Ally)
        {
            AddBonus();
            Destroy(gameObject);
        }
    }

    public void AddBonus()
    {  
        _player.Health += _health;
    }
}
