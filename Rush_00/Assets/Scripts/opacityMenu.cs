using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opacityMenu : MonoBehaviour {
	public GameObject Menu;
	public float limite;
	private int z = 0;
	public float angle = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (z == 1)
		{
			Menu.GetComponent<Text> ().color =  new Color(0,0,1,angle);
			angle += 0.02f;
			if(angle > 1)
				z = 0;
		}
		else
		{
			Menu.GetComponent<Text> ().color =  new Color(0,0,1,angle);
			angle -= 0.02f;
			if(angle < 0)
				z = 1;
		}
	}
}
