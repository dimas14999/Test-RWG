using Gameplay.Spaceships;
using Gameplay.Weapons;
using UI.Logic;
using UnityEngine;

public class Enemy : Spaceship
{

    //  Create delegate and events to track dead enemies
    public delegate void EnemyIsDead(int count);

    public event EnemyIsDead EnemyDead;

    private const int SCORE = 1;

    private UILogic _uiLogic;

    [SerializeField] private GameObject[] _itemDrop;


    protected override void Start()
    {
        base.Start();
        _uiLogic = FindObjectOfType<UILogic>();
        EnemyDead += OnEnemyDead;
    }

    // 50 percent of the appearance of the bonus
    private void DropItem()
    {
        var random = Random.Range(1, 100);
        if (random <= 50)
        {
            Instantiate(_itemDrop[Random.Range(0, _itemDrop.Length)], transform.position, Quaternion.identity);
        }
    }

    private void OnEnemyDead(int score)
    {
        _uiLogic.AddScore(score);
    }

    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        EnemyDead?.Invoke(SCORE); 
        DropItem();
        Destroy(gameObject);
    }
}
