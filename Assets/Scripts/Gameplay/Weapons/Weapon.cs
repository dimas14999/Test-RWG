using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private Projectile _projectile;

        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;

        //Добавляем свойство для подсчета и вывода на экран скорости снаряда
        public float CoolDown { get => _cooldown; set => _cooldown = value; }

        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;
        
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            StartCoroutine(Reload(_cooldown));
        }

        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }

    }
}
