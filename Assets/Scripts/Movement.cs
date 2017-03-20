using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class Movement : MonoBehaviour
{

    public float moveSpeed;//скорость движения
    public Boundary boundary;//границы 
    public Rigidbody2D rd;//
    public GameObject Shot;//обьект  выстрела
    public Transform ShotPoint;//точка выстрела
    public float fireRate = 0.5f;//задержка между выстрелами
    private float nextFire = 0.0f;//выстрел 
    public Slider BarPlayer;
    public int HP;//очки 
    public GameObject RestartPanel;//панель ,показываеться после поражения 
    public Sprite[] spriteToChangeTo;
    private float times;
    public Image myImageToUpdate1;
    // Use this for initialization
    void Start()
    {

    }
    
    void Update()
    {

        BarPlayer.value = HP;
        GetComponent<Transform>().position = new Vector2(
            Mathf.Clamp(GetComponent<Transform>().position.x,
            boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Transform>().position.y, boundary.yMin, boundary.yMax));


        #region acceleration
        Vector3 dir = Vector3.zero;
        dir.x = -Input.acceleration.y;
        dir.z = Input.acceleration.x;
        // Clamp acceleration vector to unit sphere 
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;
        GetComponent<Rigidbody2D>().transform.Translate(dir * 10);
        #endregion

        #region onKeyDownHandler
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
        }
        #endregion

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;//время следущего выстрела
            if (Shot != null)
            {
                Instantiate(Shot, ShotPoint.position, ShotPoint.rotation);//создание выстрела(нового префарба)
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")//если враг ударил по нашему персонажу убираем жизнь 
        {
            HP--;

        }
        if (HP == 0)
        {

            Destroy(gameObject);//освобождаем ненужные ресурсы 
            Destroy(other);
            RestartPanel.SetActive(true);//панель
        }

    }

}
