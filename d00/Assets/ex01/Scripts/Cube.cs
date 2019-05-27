using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public float minspeed;
    public float maxspeed;

    private float speed;

	// Use this for initialization
	void Start () {
        speed = Random.Range(minspeed, maxspeed);
	}
	
	// Update is called once per frame
	void Update () {

        //On ne peux plus jouer apres le passage de la ligne
        if (transform.localPosition.y > -2.55)
        {
            //Playing with a
            if (name[0] == 'a')
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("Precision: " + (transform.localPosition.y + 2.55f));
                    GameObject.Destroy(gameObject);
                }
            }

            //Playing with s
            if (name[0] == 's')
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("Precision: " + (transform.localPosition.y + 2.55f));
                    GameObject.Destroy(gameObject);
                }
            }

            //Playing with d
            if (name[0] == 'd')
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("Precision: " + (transform.localPosition.y + 2.55f));
                    GameObject.Destroy(gameObject);
                }
            }
        }

        // Destroy it after out of screen
        if (transform.localPosition.y < -5.5f)
        {
            GameObject.Destroy(gameObject);
        }
        // move down
        transform.Translate(0, -Time.deltaTime * speed, 0);
        
	}
}
