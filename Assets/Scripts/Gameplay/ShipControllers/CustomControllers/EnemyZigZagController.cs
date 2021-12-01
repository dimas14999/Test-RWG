using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyZigZagController : ShipController
{

    private float _frequency = 1.0f;
    private float _amplitude = 10.0f;
    private float _cycleSpeed = 6.0f;

    private Vector3 _position;
    private Vector3 _axis;

    private void Awake()
    {
        _position = transform.position;
        _axis = transform.right;
    }

    //Sets the movement to the enemy in a zigzag
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        BaseProcessHalding(movementSystem);
        _position += Vector3.down * Time.deltaTime * _cycleSpeed;
        transform.position = _position + _axis * Mathf.Sin(Time.time * _frequency) * _amplitude;
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        BaseProcessFire(fireSystem);
    }


}
