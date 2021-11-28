using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyZigZagController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    private bool _fire = true;

    private float _frequency = 1.0f;
    private float _amplitude = 10.0f;
    private float _cycleSpeed = 6.0f;

    private Vector3 pos;
    private Vector3 axis;

    private void Awake()
    {
        pos = transform.position;
        axis = transform.right;

    }

    //Sets the movement to the enemy in a zigzag
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
        pos += Vector3.down * Time.deltaTime * _cycleSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * _frequency) * _amplitude;
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
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
}
