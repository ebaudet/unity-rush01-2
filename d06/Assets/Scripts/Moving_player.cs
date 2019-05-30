using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_player : MonoBehaviour {

    public float run;
    public float walk;
    public GameObject runSound;


	private float speed;
    private GameObject player;
    private Sneaky sneaky;
    private bool isruning;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        sneaky = player.GetComponent<Sneaky>();
        isruning = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        isruning = false;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            isruning = true;
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            isruning = true;
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            isruning = true;
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            isruning = true;
            transform.Translate(Vector3.back * speed * Time.fixedDeltaTime);

        }
	}

	private void Update()
	{
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = run;
            if (isruning)
            {
				sneaky.isrunning = true;
				runSound.SetActive(true);
            }
			else
            {
                sneaky.isrunning = false;
                runSound.SetActive(false);
            }
        }
        else
        {
            runSound.SetActive(false);
            speed = walk;
            sneaky.isrunning = false;
        }
	}
}
