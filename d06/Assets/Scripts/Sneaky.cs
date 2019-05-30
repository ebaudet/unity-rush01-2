using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sneaky : MonoBehaviour {

    public Slider slider;
    public GameObject[] sounds;


    public float detection;
    public float undetection;
    public float camDetection;
    public bool isdetected;
    public bool isrunning;
    public bool iscamera;
    public float smoke;
	// Use this for initialization
	void Start () {
        isdetected = false;
        isrunning = false;
        iscamera = false;
        smoke = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isdetected || isrunning || iscamera)
        {
            if(iscamera)
                slider.value += (camDetection - smoke) * Time.deltaTime;
            else
                slider.value += detection * Time.deltaTime;
        }
        else
        {
            slider.value -= undetection * Time.deltaTime;
        }
        if (slider.value >= 75)
        {
            sounds[0].SetActive(false);
            sounds[1].SetActive(true);
            sounds[2].SetActive(true);
			if (slider.value >= 100)
            {
                Debug.Log("Perdu");
				Application.LoadLevel(Application.loadedLevel);
            }
        }
        else
        {
            sounds[0].SetActive(true);
            sounds[1].SetActive(false);
            sounds[2].SetActive(false);
        }
	}
}
