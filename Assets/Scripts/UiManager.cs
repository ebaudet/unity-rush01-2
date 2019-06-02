using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {
	public static string ToolTip;
	public GameObject InventoryUi;
	public GameObject PlayerWeaponSlot;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			GameManager.gm.Dropping = !InventoryUi.activeSelf;
			GameManager.gm.Dropping = false;
			ToolTip = "";
			InventoryUi.SetActive(!InventoryUi.activeSelf);
		}

		if (PlayerWeaponSlot.transform.childCount > 0) {
			GameManager.gm.PlayerExtraStats.Weapon = PlayerWeaponSlot.transform.GetChild(0).GetComponent<Weapon>();
		} else {
			GameManager.gm.PlayerExtraStats.Weapon = null;
		}
	}
}
