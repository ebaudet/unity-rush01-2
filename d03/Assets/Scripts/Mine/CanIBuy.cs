using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanIBuy : MonoBehaviour {

    public towerScript tower;
    private DragMe DragMe; 
    private Image image; 
	// Use this for initialization
	void Start () {
        DragMe = GetComponent<DragMe>();
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (tower.energy > gameManager.gm.playerEnergy)
        {
            DragMe.enabled = false;
            image.color = new Vector4(255f, 0f, 0f, 255f);
        }
        else
        {
            DragMe.enabled = true;
            image.color = new Vector4(255f, 255f, 255f, 255f);
        }
	}
}
