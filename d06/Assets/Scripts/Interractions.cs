using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractions : MonoBehaviour {

    public bool fan;
    public bool card;
    public bool door;
    public bool paper;
    public GameObject particules;
    public GameObject kard;
    public GameObject doors;
    public GameObject papers;
    public GameObject keySounds;
    public GameObject doorsound;


    public bool haveCard;
    public bool havePaper;
	// Use this for initialization
	void Start () {
        fan = false;
        card = false;
        haveCard = false;
        door = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && fan)
        {
            particules.SetActive(!particules.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.E) && card)
        {
            kard.SetActive(!kard.activeSelf);
            haveCard = true;
            card = false;
            keySounds.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && door && haveCard)
        {
            doors.SetActive(!doors.activeSelf);
            doorsound.SetActive(false);
            doorsound.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && paper)
        {
            papers.SetActive(!papers.activeSelf);
            havePaper = true;
            paper = false;
            Debug.Log("You Win !");
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
