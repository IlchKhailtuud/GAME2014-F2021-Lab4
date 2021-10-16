 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullet Movement")] 
    public Vector3 bulletVelocity;
    public Bounds bulletBounds;
    
    public BulletType type;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += bulletVelocity;
    }

    private void CheckBounds()
    {
        if (transform.position.y < bulletBounds.max)
        {
            BulletManager.Instance().ReturnBullet(gameObject, type);
        }
        
        if (transform.position.y > bulletBounds.min)
        {
            BulletManager.Instance().ReturnBullet(gameObject, type);
        }
    }
}
