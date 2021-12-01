using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
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

