using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyRocketController : ShipController
{
    protected override void ProcessHandling(MovementSystem movementSystem) 
    {
        BaseProcessHalding(movementSystem);
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        BaseProcessFire(fireSystem);
    }


}
