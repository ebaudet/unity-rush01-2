using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMenu : MonoBehaviour {
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
			Menu.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			angle += 0.1f;
			if(angle > limite)
				z = 0;
		}
		else
		{
			Menu.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			angle -= 0.1f;
			if(angle < -limite)
				z = 1;
		}
	}
}
