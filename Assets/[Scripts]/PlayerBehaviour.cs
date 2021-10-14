using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")] 
    [Range(0.0f, 200.0f)]
    public float horizontalForce;
    [Range(0.0f  , 1.0f)]
    public float decay;
    public Bounds bounds;

    [Header("Player Attack")] 
    public Transform bulletSpawn;
    public int frameDelay;
    
    private Rigidbody2D _rigidbody2D;
    private BulletManager bulletManager;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        bulletManager = GameObject.FindObjectOfType<BulletManager>();
    }
    
    private void FixedUpdate()
    {
        move();
        CheckBounds();
        CheckFire();
    }

    private void move()
    {
        var x = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.AddForce(new Vector2(x * horizontalForce, 0.0f));
        _rigidbody2D.velocity *= (1.0f - decay);
    }
    
    private void CheckBounds()
    {
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }
        
        if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }

    private void CheckFire()
    {
        if ((Time.frameCount % frameDelay == 0) && (Input.GetAxisRaw("Jump") > 0 ))
        {
            bulletManager.GetBullet(bulletSpawn.position, BulletType.PLAYER);
        }
    }
}
