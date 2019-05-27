using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uiStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "Player Energy :" + gameManager.gm.playerEnergy.ToString() + "\n\nPlayer HP :" + gameManager.gm.playerHp.ToString();
	}
}
