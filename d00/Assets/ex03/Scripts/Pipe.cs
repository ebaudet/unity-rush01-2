using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public float speed;
    public Bird bird;
    public bool count = true;
    public float score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (!bird.go)
        {
            speed = 3;
        }
        //Boucle des tuyaux
        if (bird.go)
        {
            if (transform.localPosition.x <= -5.5f)
            {
                transform.Translate(12f, 0, 0);
                count = true;
            }
            if (transform.localPosition.x <= -1.39 && count)
            {
                score += 5;
                count = false;
            }
            transform.Translate(-Time.deltaTime * speed, 0, 0);
            speed += (Time.deltaTime / 4);
        }
	}
}
