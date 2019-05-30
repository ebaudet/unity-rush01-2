using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

    private GameObject player;
    private Sneaky sneaky;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sneaky = player.GetComponent<Sneaky>();
    }

	private void OnTriggerEnter(Collider other)
	{
        sneaky.smoke = 200;
	}

	private void OnTriggerExit(Collider other)
	{
        sneaky.smoke = 0;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
