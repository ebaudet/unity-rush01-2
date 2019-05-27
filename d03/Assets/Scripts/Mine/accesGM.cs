using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class accesGM : MonoBehaviour {

    public GameObject nxtlvl;
    public GameObject Score;
    public GameObject Rang;
    public GameObject resultat;
    private int rank = 0;
    private float hp;
    private float energy;
    private string rank_txt = "EDCBAS";

	// Use this for initialization
	void Start () {
        hp = (float)gameManager.gm.playerHp;
        energy = (float)gameManager.gm.playerEnergy;
		Score.GetComponent<Text>().text = "Votre Score : " + gameManager.gm.score.ToString();

        if (hp >= 10)
            rank += Mathf.FloorToInt(Mathf.FloorToInt(hp / 10) + Mathf.FloorToInt(hp / 10 - 1));
        Debug.Log(rank);

        if (energy >= 500)
            rank += 1;
        if (energy >= 1000)
            rank += 1;
        if (hp > 0)
		    resultat.GetComponent<Text>().text = "Victoire !";
        else
            resultat.GetComponent<Text>().text = "Defaite !";
        if (hp <= 0)
        {
            nxtlvl.SetActive(false);
            rank = 0;
        }
        Rang.GetComponent<Text>().text = "Votre rang :" + rank_txt[rank];

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Retry_lvl()
    {
        Application.LoadLevel(gameManager.gm.currentlvl);
    }
}
