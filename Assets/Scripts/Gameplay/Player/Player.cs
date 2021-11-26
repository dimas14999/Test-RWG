using Gameplay.Spaceships;
using Gameplay.Weapons;
using UnityEngine;

//Класс для контроля игрока
public class Player : Spaceship, IBonusDealer
{
    [SerializeField] private int _score = 1; //

    [SerializeField] private float _health = 150;

    [SerializeField] private Weapon[] _weapons;

    //Добавляем событие для обновления здоровья игрока
    public delegate void PlayerIsDamage(float health);
    public static event PlayerIsDamage HealthDamage;

    //Добавляем событие для обновления скорости снаряда игрока
    public delegate void Energy(float energy);
    public static event Energy PlayerEnergy;

    protected override void Start()
    {
        base.Start();
        HealthDamage?.Invoke(_health);
        foreach (var item in _weapons)
        {
            PlayerEnergy?.Invoke(item.CoolDown);
        }
        
    }

    //Сравниваю с каким бонусом столкнулся игрок
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

                            if (item.CoolDown <= 0.02f) return;
                            item.CoolDown -= energyBonus.AddEnergy;
                            PlayerEnergy?.Invoke(item.CoolDown);
                        }
                    }
                    break;
                }
        }
    }
    public override void ApplyDamage(IDamageDealer damageDealer)
    {
        _health -= damageDealer.Damage;
        HealthDamage?.Invoke(_health);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

 
}
