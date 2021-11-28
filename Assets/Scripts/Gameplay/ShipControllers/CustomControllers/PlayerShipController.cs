using Gameplay.ShipSystems;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime;

            //We check if the movement occurs within the camera along the x axis or not
            if (!GameAreaHelper.IsInGameplayAreaPlayer(transform, _spriteRenderer.bounds, deltaX)) return;
     
            movementSystem.LateralMovement(deltaX);
            
            
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
