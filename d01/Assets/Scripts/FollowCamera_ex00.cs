using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera_ex00 : MonoBehaviour {

    public playerScript_ex00 playerScript;
    public Vector3 playerposition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playerposition = new Vector3(playerScript.players[playerScript.current].transform.localPosition.x, playerScript.players[playerScript.current].transform.localPosition.y, -10);
        transform.position = playerposition;
	}
}
