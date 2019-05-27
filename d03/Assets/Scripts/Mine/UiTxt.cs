using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UiTxt : MonoBehaviour {
    
    public towerScript tower;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Name :" + tower.name + "\nCost :" + tower.energy.ToString() + "\nRange :" + tower.range.ToString() + "\nDammage :" + tower.damage.ToString() + "\nFire Rate :" + tower.fireRate.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
