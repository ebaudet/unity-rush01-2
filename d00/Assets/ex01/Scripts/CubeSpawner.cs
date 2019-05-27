using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    public Transform[] boxes;
    public float[] xcoors;

	private float[] times = {0,0,0};
	// Use this for initialization
	void Start () {
        // On initialise les temps de spawn
        for (var i = 0; i < 2; i++)
        {
                times[i] = Random.Range(3f, 5f);
        }
	}
	
	// Update is called once per frame
	void Update () {

        // On check les temps de spawn puis on spawn puis on recree un temps de spawn entre 3/5
        for (var i = 0; i < 3; i++)
        {
            times[i] -= Time.deltaTime;
            if (times[i] <= 0)
            {
				Instantiate(boxes[i], new Vector3(xcoors[i], 5f, 0), Quaternion.identity);
                times[i] = Random.Range(3, 5);
            }
        }
	}
}
