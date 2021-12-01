﻿using System;
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

        public virtual float Health { get; set; }

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        protected virtual void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }


        //Changed the class and method to override the ApplyDamage method in the Enemy and Player classes
        public abstract void ApplyDamage(IDamageDealer damageDealer);
    }
}
