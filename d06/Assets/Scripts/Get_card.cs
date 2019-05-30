using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_card : MonoBehaviour {

    private GameObject player;
    private Interractions interractions;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        interractions = player.GetComponent<Interractions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        interractions.card = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interractions.card = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
