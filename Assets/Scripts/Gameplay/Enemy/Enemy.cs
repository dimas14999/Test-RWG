using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

public class Enemy : Spaceship
{

    //  Создаю делегат и событи для отслеживания умерших врагов
    public delegate void EnemyIsDead(int count);

    public static event EnemyIsDead EnemyDead;

    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        EnemyDead?.Invoke(1); // Вызовает событие после убийства врага
        Destroy(gameObject);
    }
}
