using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl_script : MonoBehaviour
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
        txt.text = "lvl. " + player.level;
    }
}
