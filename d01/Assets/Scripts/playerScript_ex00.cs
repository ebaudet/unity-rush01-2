using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

    public GameObject[] players;

    private Rigidbody2D rb2d;

    public float speed;
    public int jump;
    public int current;

	// Use this for initialization
	void Start () {
        current = 0;
        players = GameObject.FindGameObjectsWithTag("Player");
        rb2d = players[0].GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("ex00");
        }
        if (Input.GetKeyDown("1"))
        {
            current = 0;
            rb2d = players[0].GetComponent<Rigidbody2D>();
            rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyDown("2"))
        {
            current = 1;
            rb2d = players[1].GetComponent<Rigidbody2D>();
            rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyDown("3"))
        {
            current = 2;
            rb2d = players[2].GetComponent<Rigidbody2D>();
            rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        }
       // MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
		
	}

	private void FixedUpdate()
	{
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        if (rb2d == GetComponent<Rigidbody2D>())
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.left.x * 5, rb2d.velocity.y);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.right.x * 5, rb2d.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(rb2d.velocity.x, Vector2.up.y * 5);
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

	}
}