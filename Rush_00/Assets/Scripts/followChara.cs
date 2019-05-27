using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followChara : MonoBehaviour {
	public Camera Camera;
	public GameObject Hero;
	private int neverCall = 1;
	public AudioSource audi;

	// Update is called once per frame
	void Update () {
        if(Hero)
		Camera.transform.position = new Vector3(Hero.transform.position.x, Hero.transform.position.y, Camera.transform.position.z);
			if(!Hero && neverCall == 1)
			{
				audi.Play();
				neverCall = 0;
			}
	}
}
