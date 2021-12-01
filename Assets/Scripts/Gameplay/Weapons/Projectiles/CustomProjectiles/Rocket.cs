using Gameplay.Weapons.Projectiles;
using UnityEngine;


//Class with logic of rocket movement
public class Rocket : Projectile
{
    private float _frequency = 14.0f;
    private float _amplitude = 10.0f;
    private float _cycleSpeed = 20.0f;

    private Vector3 _position;
    private Vector3 _axis;

    private void Awake()
    {
        _position = transform.position;
        _axis = transform.right;
    }
    protected override void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
        _position += Vector3.down * Time.deltaTime * _cycleSpeed;
        transform.position = _position + _axis * Mathf.Sin(Time.time * _frequency) * _amplitude;

    }
}
