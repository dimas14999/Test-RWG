using Gameplay.ShipSystems;
using Gameplay.Spaceships;
using System.Collections;
using UnityEngine;

namespace Gameplay.ShipControllers
{
    public abstract class ShipController : MonoBehaviour
    {

        private ISpaceship _spaceship;

        [SerializeField]
        protected Vector2 _fireDelay;

        protected bool _fire = true;

        public void Init(ISpaceship spaceship)
        {
            _spaceship = spaceship;
        }

        private void Update()
        {
            ProcessHandling(_spaceship.MovementSystem);
            ProcessFire(_spaceship.WeaponSystem);
        }

        protected virtual void BaseProcessHalding(MovementSystem movementSystem)
        {
            movementSystem.LongitudinalMovement(Time.deltaTime);
        }
        protected virtual void BaseProcessFire(WeaponSystem fireSystem)
        {
            if (!_fire)
                return;

            fireSystem.TriggerFire();
            StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
        }

        private IEnumerator FireDelay(float delay)
        {
            _fire = false;
            yield return new WaitForSeconds(delay);
            _fire = true;
        }

        protected abstract void ProcessHandling(MovementSystem movementSystem);
        protected abstract void ProcessFire(WeaponSystem fireSystem);
    }

      
}

