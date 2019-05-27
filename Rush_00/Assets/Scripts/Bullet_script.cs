using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_script : MonoBehaviour {

    public Vector3 player_position;
    public float speed;
    private Vector3 origine;
    public float life_time;
    private float time = 0f;
    public float offset;
    public bool hero = false;
    public float fire_rate = 2f;
	// Use this for initialization
	void Start () {
        origine = transform.position;
        Destroy(gameObject, life_time);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += (player_position - origine).normalized * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Player" && !Gamemanager.gm.unkillable)
        {
            Gamemanager.gm.dead = true;
            Destroy(collision.gameObject);
        }
        if (hero && collision.tag == "Ennemy")
        {
            Gamemanager.gm.nbr_ennemy -= 1;
            Destroy(collision.gameObject);
        }
		Destroy(gameObject);
    }
}
