using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInLight : MonoBehaviour {

    public GameObject player;
    private Sneaky sneaky;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        sneaky = player.GetComponent<Sneaky>();
	}

	private void OnTriggerEnter(Collider other)
	{
        sneaky.isdetected = true;
	}
	private void OnTriggerExit(Collider other)
	{
        sneaky.isdetected = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
