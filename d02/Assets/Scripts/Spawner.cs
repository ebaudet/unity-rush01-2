using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject hero;
    public float time;
    public float spawn_time;
    public Vector3 spawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= spawn_time)
        {
            time = 0;
            Instantiate(hero, spawn, Quaternion.identity);
        }
		
	}
}
