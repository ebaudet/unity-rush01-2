using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_trigger : MonoBehaviour {

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
        sneaky.iscamera = true;
    }
    private void OnTriggerExit(Collider other)
    {
        sneaky.iscamera = false;
    }
}
