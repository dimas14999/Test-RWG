using Gameplay.ShipSystems;
using UnityEngine;

public class EnergyBonus : MonoBehaviour, IBonus
{
    public ItemBonus Bonus { get => ItemBonus.Energy; }

    [SerializeField] private float _addEnergy = 0.01f;
    public float AddEnergy { get => _addEnergy; }

    [SerializeField] private MovementSystem _movementSystem;

    private void Update()
    {
        _movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.gameObject.GetComponent<Player>();

        if (item == null) return;

        item.TakeBonus(this);
        Destroy(gameObject);
    }
}
