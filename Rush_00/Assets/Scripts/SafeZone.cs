using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {
	public GameObject WinTxt1;
	public GameObject WinTxt2;
	public GameObject WinBtn1;
	public GameObject Panel;

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Hero")
		{
				Time.timeScale = 0;
			Panel.SetActive(true);
			WinTxt1.SetActive(true);
			WinTxt2.SetActive(true);
			WinBtn1.SetActive(true);
		}
	}
}
