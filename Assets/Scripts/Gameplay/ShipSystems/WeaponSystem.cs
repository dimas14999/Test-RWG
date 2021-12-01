using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour
    {

        [SerializeField]
        private List<Weapon> _weapons;

        public List<Weapon> Weapons => _weapons;

        private const float MaxCoolDown = 0.02f;

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
        
        
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        public void DecreaseCoolDown(float energy)
        {
            _weapons.ForEach(e => {
                if (e.CoolDown <= MaxCoolDown) return;
                e.CoolDown -= energy;
                });
        }

    }
}
