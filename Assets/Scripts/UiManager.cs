﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static string ToolTip;
    public GameObject InventoryUi;
    public GameObject PlayerWeaponSlot;

    private void Awake()
    {
        PlayerWeaponSlot = GameObject.Find("PlayerWeaponSlot");
    }
    // Use this for initialization
    void Start()
    {
        InventoryUi = GameObject.Find("InventoryUI");
        InventoryUi.SetActive(false);
        ToolTip = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.gm.Dropping = !InventoryUi.activeSelf;
            GameManager.gm.Dropping = false;
            ToolTip = "";
            InventoryUi.SetActive(!InventoryUi.activeSelf);
        }

        if (PlayerWeaponSlot.transform.childCount > 0)
        {
            GameManager.gm.Player.Weapon = PlayerWeaponSlot.transform.GetChild(0).GetComponent<Weapons>();
        }
        else
        {
            GameManager.gm.Player.Weapon = null;
        }
    }

    private void OnGUI()
    {
        GUI.Label(
            new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, ToolTip.Length * 10,
                20 * ToolTip.Replace(System.Environment.NewLine, string.Empty).Length), ToolTip);
    }
}
