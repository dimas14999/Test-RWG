using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;


namespace Gameplay.Spaceships
{
    public abstract class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        protected virtual void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }


        //Изменил класс и метод чтоб переопределить метод ApplyDamage в классе Enemy и Player
        //public  void ApplyDamage(IDamageDealer damageDealer)
        //{
        //    EnemyDead?.Invoke(1); // Вызовает событие после убийства врага
        //    Destroy(gameObject);
        //}
        public abstract void ApplyDamage(IDamageDealer damageDealer);
    }
}
