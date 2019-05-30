using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_door : MonoBehaviour {

    private GameObject player;
    private Interractions interractions;
    public GameObject doors;
    public MeshRenderer locker;
    public Material locked;
    public Material open;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        interractions = player.GetComponent<Interractions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        interractions.door = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interractions.door = false;
    }

	private void Update()
	{
        if (doors.activeSelf)
        {
            locker.material = locked;

        }
        else
        {
            locker.material = open;

        }
	}
}
