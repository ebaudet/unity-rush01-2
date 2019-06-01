using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public Transform player;
    public float y;
    public bool dropping = false;
    public GameObject Player;

    // Use this for initialization
    void Awake()
    {
        y = 9.5f;
        if (gm != null && gm != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        gm = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0, y, 10);
    }
}