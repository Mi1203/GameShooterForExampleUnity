using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public float velocityEnemy;
    public int scoreValue;
    public ScoreManager scoreManager;
    public GameObject Explosion;
    public Animation anim;
    public GameObject Shot;
    public Transform ShotSpawn;
    public bool canShot;
    public float fireShot = 0.5F;
    private float nextFire = 0.0F;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        scoreManager = FindObjectOfType<ScoreManager>();
       // anim = GetComponent<Animation>();
    }
    void Update()
    {
        if (Time.time > nextFire)
        {nextFire = Time.time + fireShot;
            if (canShot)
            {
               // if(ShotSpawn != null)
                Instantiate(Shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            scoreManager.score += scoreValue = 200;
        }
        // if()
    }

}
