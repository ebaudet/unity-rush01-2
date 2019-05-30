using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_paper : MonoBehaviour {

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
        interractions.paper = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interractions.paper = false;
    }
}
