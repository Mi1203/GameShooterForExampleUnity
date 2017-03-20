using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack : MonoBehaviour
{//враги
    public float velocityEnemy;
    public int scoreValue;
    public ScoreManager scoreManager;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;//движение кораблей врагов 
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter2D(Collider2D other)//столкновение с другим обьектом обьектом 
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            if (gameObject.tag != "image")
                Destroy(gameObject);
            scoreManager.score += scoreValue = 200;
        }
    }

}
