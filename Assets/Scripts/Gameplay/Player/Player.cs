using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

//Player control class
public class Player : Spaceship, IBonusDealer
{
    [SerializeField] private int _score = 1; 

    [SerializeField] private float _health = 150;

    [SerializeField] private Weapon[] _weapons;

    //Add an event to update the player's health
    public delegate void PlayerIsDamage(float health);
    public static event PlayerIsDamage HealthDamage;

    //Add an event to update the player's projectile speed
    public delegate void Energy(float energy);
    public static event Energy PlayerEnergy;

    public delegate void PlayerIsDead();
    public static event PlayerIsDead PlayerDead;

    private const float MaxCoolDown = 0.02f;

    protected override void Start()
    {
        base.Start();
        HealthDamage?.Invoke(_health);
        foreach (var item in _weapons)
        {
            PlayerEnergy?.Invoke(item.CoolDown);
        }
        
    }

    //I compare with what bonus the player faced
    public void TakeBonus(IBonus bonus)
    {
        switch (bonus.Bonus)
        {
            case ItemBonus.Health:
                {
                    if (bonus is HealthBonus healthBonus)
                    {
                        _health += healthBonus.AddHealth;
                        HealthDamage?.Invoke(_health);
                    }
                    break;
                }
            case ItemBonus.Energy:
                {
                    if (bonus is EnergyBonus energyBonus)
                    {
                        foreach (var item in _weapons)
                        {

                            if (item.CoolDown <= MaxCoolDown) return;
                            item.CoolDown -= energyBonus.AddEnergy;
                            PlayerEnergy?.Invoke(item.CoolDown);
                        }
                    }
                    break;
                }
        }
    }

    // The method responsible for the player's damage and his further actions
    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        _health -= damageDealer.Damage;
        HealthDamage?.Invoke(_health);
        if (_health <= 0)
        {
            PlayerDead?.Invoke();
            Destroy(gameObject);
            
        }
    }

 
}
