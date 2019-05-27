using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int ok;
    public List<Player>  humans;
    public int nbr_human;
    public int selected_human = 0;
    public string whereismouse = "nothing";
	private GameController() { } //au cas où certains fous tenteraient qd même d'utiliser le mot clé "new"

    public static GameController instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        instance = this;
    }

	// Update is called once per frame
	void Update () {
        nbr_human = humans.Count;
        selected_human = 0;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        foreach (var human in humans)
        {
            if(human.selected)
                selected_human += 1;
            
        }
    }

	public void reset()
	{
            foreach (var man in humans)
            {
                if(man.reset == true)
                {
			        man.selected = false;
                }
                man.reset = true;
            }
	}
}
