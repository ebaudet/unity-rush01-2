using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nbrBalle : MonoBehaviour {
	public GameObject Hud;
	public GameObject Hud_name;
	private string name;
	private string weapon_name;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		weapon_name = Gamemanager.gm.weapon_name.ToString();
		Hud_name.GetComponent<Text>().text = weapon_name;

		if(weapon_name == "No weapon")
		 	name = "0";
		else if(-1 >= Gamemanager.gm.ammo)
			name = "infini";
		else
			name = Gamemanager.gm.ammo.ToString();
		Hud.GetComponent<Text>().text = name;
	}
}
