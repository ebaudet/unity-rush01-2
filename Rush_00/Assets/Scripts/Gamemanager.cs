using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {

    public bool fire = false;
    public static Gamemanager gm;
    public bool dead = false;
    public int nbr_ennemy;
    public float ammo;
    public string weapon_name;
    public bool unkillable = false;
    private float time;

	// Use this for initialization
    void Awake()
    {
        if (gm != null && gm != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        gm = this;
        weapon_name = "No weapon";
        time = 0;
    }

	// Update is called once per frame
	void Update () {
        if (unkillable == true)
        {
            time += Time.deltaTime;
        }
        if (time > 3)
        {
            unkillable = false;
        }
	}
}
