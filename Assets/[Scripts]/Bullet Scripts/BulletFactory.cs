using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    private static BulletFactory instance;

    public GameObject enemyBullet;
    public GameObject playerBullet;

    private GameController gameController;

    private BulletFactory()
    {
        Initialize();
    }

    public static BulletFactory Instance()
    {
        if (instance == null)
        {
            instance = new BulletFactory();
        }

        return instance;
    }

    private void Initialize()
    {
        enemyBullet = Resources.Load("Prefabs/EnemyBullet") as GameObject;
        playerBullet = Resources.Load("Prefabs/PlayerBullet") as GameObject;
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    
    public GameObject createBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch (type)
        {
            case BulletType.ENEMY:
                temp_bullet = MonoBehaviour.Instantiate(enemyBullet);
                break;
            case BulletType.PLAYER:
                temp_bullet = MonoBehaviour.Instantiate(playerBullet);
                break;
        }

        temp_bullet.transform.parent = gameController.gameObject.transform;
        temp_bullet.SetActive(false);
        
        return temp_bullet;
    }
}
