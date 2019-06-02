using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_1 : MonoBehaviour
{

    public Move_maya player;
    public Text txt;

    private void Awake() {
        if (!player)
            player = GameObject.Find("Maya").GetComponent<Move_maya>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.alive)
            return;
        txt.text = "FOR = " + player.STR + "\n\nAGI = " + player.AGI + "\n\nCON = " + player.CON + "\n\ndmgMin = " + player.minDMG + "\n\ndmgMax = " + player.maxDMG;
    }
}
