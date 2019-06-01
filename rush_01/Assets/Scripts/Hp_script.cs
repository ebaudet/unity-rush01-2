using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_script : MonoBehaviour {

    public Slider slider;
    public Move_maya player;
    public Text txt;
	// Use this for initialization
	void Start () {
        slider.minValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
        slider.maxValue = player.CON * 5;
        slider.value = player.hp;
        txt.text = Mathf.Clamp(player.hp, 0, player.CON * 5) + "/" + player.CON * 5;

	}
}
