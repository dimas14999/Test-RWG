using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

public class Enemy : Spaceship
{

    //  Создаю делегат и событи для отслеживания умерших врагов
    public delegate void EnemyIsDead(int count);

    public static event EnemyIsDead EnemyDead;

    [SerializeField] private GameObject[] _itemDrop;

    // 50-ти процент появления бонуса 
    private void DropItem()
    {
        var random = Random.Range(1, 100);
        if (random <= 50)
        {
            Instantiate(_itemDrop[Random.Range(0, _itemDrop.Length)], transform.position, Quaternion.identity);
        }
    }
    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        EnemyDead?.Invoke(1); // Вызовает событие после убийства врага
        DropItem();
        Destroy(gameObject);
    }
}
