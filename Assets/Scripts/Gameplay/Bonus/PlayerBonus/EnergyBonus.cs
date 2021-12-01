using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using Gameplay.Weapons;
using UI.Logic;
using UnityEngine;

public class EnergyBonus : MonoBehaviour, IBonus
{

    [SerializeField] private float _addEnergy = 0.05f;
    [SerializeField] private MovementSystem _movementSystem;

    //Add an event to update the player's projectile speed
    public delegate void Energy(float energy);
    public event Energy PlayerEnergy;

    private Spaceship _player;
    private UILogic _uiLogic;

    private void Start()
    {
        _uiLogic = FindObjectOfType<UILogic>();
        PlayerEnergy += OnAddEnergy;
    }

    private void Update()
    {
        _movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player = collision.gameObject.GetComponent<Spaceship>();

        if (_player != null && _player.BattleIdentity == UnitBattleIdentity.Ally)
        {
            AddBonus();
            Destroy(gameObject);
        }
    }
    private void OnAddEnergy(float energy)
    {
        _uiLogic.AddEnergy(energy);
    }

    public void AddBonus()
    {
        _player.WeaponSystem.DecreaseCoolDown(_addEnergy);
        UpdateCollDown();
    }
    private void UpdateCollDown()
    {
        foreach (var item in _player.WeaponSystem.Weapons)
        {
            PlayerEnergy?.Invoke(item.CoolDown);
        }
    }
}
