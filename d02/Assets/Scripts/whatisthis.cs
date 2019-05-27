using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whatisthis : MonoBehaviour {

    // Use this for initialization
    public string iama;
	void Start () {
		
	}

	private void OnMouseEnter()
	{
        iama = tag;
        GameController.instance.whereismouse = iama;
	}
	private void OnMouseExit()
	{
        iama = "nothing";
        GameController.instance.whereismouse = iama;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
