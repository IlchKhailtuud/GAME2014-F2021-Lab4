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

    public Queue<GameObject> enemyBulletPool;
    public Queue<GameObject> playerBulletPool;
    public int enemyBulletNumber;
    public int playerBulletNumber;
    
    private void Initialize()
    {
        enemyBulletPool = new Queue<GameObject>();
        playerBulletPool = new Queue<GameObject>();
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < enemyBulletNumber; i++)
        {
            AddBullet();
        }
    }

    private void AddBullet(BulletType type = BulletType.ENEMY)
    {
        var temp_bullet = BulletFactory.Instance().createBullet(type);

        switch (type)
        {
            case BulletType.ENEMY:
                enemyBulletPool.Enqueue(temp_bullet);
                enemyBulletNumber++;
                break;
            case BulletType.PLAYER:
                playerBulletPool.Enqueue(temp_bullet);
                playerBulletNumber++;
                break;
        }
    }

    public GameObject GetBullet(Vector2 position, BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        
        switch (type)
        {
            case BulletType.ENEMY:
                if (enemyBulletPool.Count < 1)
                {
                    AddBullet();
                }
                temp_bullet = enemyBulletPool.Dequeue();
                temp_bullet.transform.position = position;
                temp_bullet.SetActive(true);
                break;
           
            case BulletType.PLAYER:
                if (playerBulletPool.Count < 1)
                {
                    AddBullet(BulletType.PLAYER);
                }
                temp_bullet = playerBulletPool.Dequeue();
                temp_bullet.transform.position = position;
                temp_bullet.SetActive(true);
                break;
        }

        return temp_bullet;
    }

    public void ReturnBullet(GameObject returned_bullet, BulletType type = BulletType.ENEMY)
    {

        switch (type)
        {
            case BulletType.ENEMY:
                returned_bullet.SetActive(false);
                enemyBulletPool.Enqueue(returned_bullet);
                break;
            case BulletType.PLAYER:
                returned_bullet.SetActive(false);
                playerBulletPool.Enqueue(returned_bullet);
                break;
        }
    }
}
