using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

//Класс для контроля игрока
public class Player : Spaceship
{
    [SerializeField] private int _score = 1;

    [SerializeField] private int _health = 100;

    public delegate void PlayerIsDead(int health);

    public static event PlayerIsDead PlayerDead;

    protected override void Start()
    {
        base.Start();
        PlayerDead?.Invoke(_health);
    }

    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        _health -= 10;
         PlayerDead?.Invoke(_health);
        if (_health <= 0)
        {
            Destroy(gameObject);
            return; 
        }
    }

}
