using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{


    public float speedBullet;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speedBullet;//скорость оружия 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
