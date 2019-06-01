using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_pot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerStay(Collider other)
	{
        Debug.Log("TRIGGERED");
        other.GetComponent<Move_maya>().hp = (int)Mathf.Clamp(other.GetComponent<Move_maya>().hp + (int)(other.GetComponent<Move_maya>().CON * 5 * 0.3f), 0,(other.GetComponent<Move_maya>().CON * 5));
        Destroy(this.gameObject);
	}
}
