using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Stats_2 : MonoBehaviour
{
    public Move_maya player;
    public Text txt;

    private void Awake()
    {
        if (!player)
            player = GameObject.Find("Maya").GetComponent<Move_maya>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.alive)
            return;
        txt.text = "XP = " + player.xp + "\n\nNext lvl = " + AbbrevationUtility.AbbreviateNumber(player.xpForNext) + "\n\nHPmax = " + player.CON * 5 + "\n\nPoints = " + player.stats_point;
    }
}

public static class AbbrevationUtility
{
    private static readonly SortedDictionary<int, string> abbrevations = new SortedDictionary<int, string>
     {
         {1000,"K"},
         {1000000, "M" },
         {1000000000, "B" }
     };

    public static string AbbreviateNumber(float number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<int, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                int roundedNumber = Mathf.FloorToInt(number / pair.Key);
                return roundedNumber.ToString() + pair.Value;
            }
        }
        return number.ToString();
    }
}