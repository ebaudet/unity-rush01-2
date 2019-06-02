﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_button : MonoBehaviour
{
    public GameObject stats_up;
    public Move_maya player;

    private void Awake() {
        if (!player)
            player = GameObject.Find("Maya").GetComponent<Move_maya>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.stats_point > 0)
        {
            stats_up.SetActive(true);
        }
        else
            stats_up.SetActive(false);
    }
}
