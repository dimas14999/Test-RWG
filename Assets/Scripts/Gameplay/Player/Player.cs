using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

public class Player : Spaceship
{
    [SerializeField] private int _score = 1;

    [SerializeField] private int _health = 100;

    //protected override void Start()
    //{
    //    base.Start();
    //}

    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        Debug.Log($"ДО = {_health}");
        _health -= 10;
        if (_health <= 0)
            Destroy(gameObject);
        Debug.Log($"ПОСЛЕ = {_health}");
    }

}
