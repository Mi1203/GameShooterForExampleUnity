using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float time = -3f;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time <= 0) 
        {//if(gameObject.tag!="image")
            Destroy(gameObject);
        }
	}
}
