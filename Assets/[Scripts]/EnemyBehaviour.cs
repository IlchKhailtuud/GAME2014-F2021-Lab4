using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Movement")] 
    public Bounds movementBounds;
    public Bounds startingRange;

    [Header("Bulltes")] 
    public Transform bulletSpawn;
    public int frameDelay;

    private float startingPoint;
    private float randomSpeed;
    
    void Start()
    {
        randomSpeed = Random.Range(movementBounds.min, movementBounds.max);
        startingPoint = Random.Range(startingRange.min, startingRange.max);
    }
    
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) 
                                         + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % frameDelay == 0)
        {
            BulletManager.Instance().GetBullet(bulletSpawn.position);
        }
    }
}
