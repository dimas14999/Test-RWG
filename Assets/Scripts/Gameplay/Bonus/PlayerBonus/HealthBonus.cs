using Gameplay.ShipSystems;
using UnityEngine;


// Class for receiving health bonuses
public class HealthBonus : MonoBehaviour, IBonus
{
    public ItemBonus Bonus { get => ItemBonus.Health;} 

    [SerializeField] private float _addHealth = 5;
    public float AddHealth { get => _addHealth; }

    [SerializeField] private MovementSystem _movementSystem;

    private void Update()
    {
        _movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    // Player collision check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.gameObject.GetComponent<Player>();

        if (item == null) return;

        item.TakeBonus(this);
        Destroy(gameObject);
    }

}
