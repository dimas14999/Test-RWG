using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for infinite background motion
public class ScrollBackground : MonoBehaviour
{
    [SerializeField] private float _verticalSpeed = 0.2f;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    //Background motion is set
    private void Update() 
    {
        Vector2 offset = new Vector2(0, Time.time * _verticalSpeed);
        _renderer.material.mainTextureOffset = offset;
    }
}
