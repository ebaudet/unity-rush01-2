using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionPerso : MonoBehaviour {
	public Camera cam;
	private Vector3 dir;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		dir = cam.WorldToScreenPoint(transform.position);
		dir = Input.mousePosition - dir;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
	}
}
