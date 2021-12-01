using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Spawners;
using Gameplay.Weapons;
using UnityEngine;


public class Player : Spaceship
{
    [SerializeField] protected float _health = 150;

    private Spawner[] _spawners;
    public override float Health { get => _health; set { _health = value; HealthDamage?.Invoke(_health); } }

    //Add an event to update the player's health
    public delegate void PlayerIsDamage(float health);
    public event PlayerIsDamage HealthDamage;

    public delegate void PlayerIsDead();
    public event PlayerIsDead PlayerDead;

    protected override void Start()
    {
        base.Start();
        HealthDamage?.Invoke(_health);
        _spawners = FindObjectsOfType<Spawner>();
    }

    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        Health -= damageDealer.Damage;
        if (Health <= 0)
        {
            PlayerDead?.Invoke();
            foreach (var item in _spawners)
                item.StopSpawn();

            Destroy(gameObject);
        }
    }

 
}
