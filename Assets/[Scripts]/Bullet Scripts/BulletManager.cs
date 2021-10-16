using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class BulletManager
{
    private static BulletManager instance = null;

    private BulletManager()
    {
        Initialize();
    }

    public static BulletManager Instance()
    {
        if (instance == null)
        {
            instance = new BulletManager();
        }
        return instance;
    }

    public List<Queue<GameObject>> bulletPools;

    private void Initialize()
    {
        bulletPools = new List<Queue<GameObject>>();

        for (int i = 0; i < (int)BulletType.NUMBER_OF_BULLET_TYPES; i++)
        {
            bulletPools.Add(new Queue<GameObject>());
        }
    }

    // private void BuildBulletPool()
    // {
    //     for (int i = 0; i < enemyBulletNumber; i++)
    //     {
    //         AddBullet();
    //     }
    // }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = BulletFactory.Instance().createBullet(type);
        bulletPools[(int)type].Enqueue(temp_bullet);
    }

    public GameObject GetBullet(Vector2 spawnPosition, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;

        if (bulletPools[(int)type].Count < 1)
        {
            AddBullet(type);
        }

        temp_bullet = bulletPools[(int)type].Dequeue();

        temp_bullet.transform.position = spawnPosition;
        temp_bullet.SetActive(true);

        return temp_bullet;
    }

    public void ReturnBullet(GameObject returned_bullet, BulletType type = BulletType.ENEMY)
    {
        returned_bullet.SetActive(false);
        bulletPools[(int)type].Enqueue(returned_bullet);
    }
}
