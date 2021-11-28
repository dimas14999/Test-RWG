using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

public class Enemy : Spaceship
{

    //  Create delegate and events to track dead enemies
    public delegate void EnemyIsDead(int count);

    public static event EnemyIsDead EnemyDead;

    private const int SCORE = 1;

    [SerializeField] private GameObject[] _itemDrop;

    // 50 percent of the appearance of the bonus
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
        EnemyDead?.Invoke(SCORE); // Triggers an event after killing an enemy
        DropItem();
        Destroy(gameObject);
    }
}
