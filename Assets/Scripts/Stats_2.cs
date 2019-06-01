using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_2 : MonoBehaviour
{

    public Move_maya player_stats;
    public Text txt;
   
    // Update is called once per frame
    void Update()
    {
        txt.text = "XP = " + player_stats.xp + "\n\nNext lvl = " + player_stats.xpForNext + "\n\nHPmax = " + player_stats.CON * 5 + "\n\nPoints = " + player_stats.stats_point;
    }
}