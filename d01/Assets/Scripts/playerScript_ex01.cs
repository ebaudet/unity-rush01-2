using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour {

    public GameObject[] players;
    public GameObject[] plats;


    private Rigidbody2D rb2d;

    public bool iswalid = false;
    public int current;
    public string nextlvl;


    // Use this for initialization
    void Start()
    {
        current = 0;
        plats = GameObject.FindGameObjectsWithTag("button_change");
        rb2d = players[0].GetComponent<Rigidbody2D>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        // end of level
        if (collision.tag == tag)
        {
            bool allwalid = true;
            iswalid = true;
            foreach (var player in players)
            {
                if (!player.GetComponent<playerScript_ex01>().iswalid)
                    allwalid = false;
            }
            if (allwalid)
            {
                Application.LoadLevel(nextlvl);
                Debug.Log("Win !!");
            }
        }
        // teleportation
        if (collision.tag == "tp")
        {
            if (tag == "red")
            {
                if (Application.loadedLevel == 2)
                {
					transform.position = new Vector3(-7f, -0.5f, 0f);
                }
            }
            if (tag == "yellow")
            {
                if (Application.loadedLevel == 2)
                {
                    transform.position = new Vector3(10f, 3f, 0f);
                }
            }
        }
        // bouton
        if (collision.tag == "bouton")
        {
            if (tag == "red")
            {
                if (Application.loadedLevel == 3)
                {
                    foreach (var plat in plats)
                    {
                        // 14 mauve
                        if (plat.layer == 14)
                        {
							plat.layer = 0;
							plat.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1f, 1f, 1f);;
                        }
                    }
                }
            }
            if (tag == "yellow")
            {
                if (Application.loadedLevel == 3)
                {
                    foreach (var plat in plats)
                    {
                        // 15 orange
                        if (plat.layer == 15)
                        {
                            plat.layer = 0;
                            plat.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1f, 1f, 1f); ;
                        }
                    }
                }
            }
        }

    }

	private void OnTriggerExit2D(Collider2D collision)
	{
        if (collision.tag == tag)
        {
			iswalid = false;
        }
	}
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
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
                GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.left.x * rb2d.mass, rb2d.velocity.y);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(Vector2.right.x * rb2d.mass, rb2d.velocity.y);
            }
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)))
			{
                ContactPoint2D[] maurice = new ContactPoint2D[64];

                if (rb2d.GetContacts(maurice) > 0)
                {
                    foreach (ContactPoint2D momo in maurice)
                    {
                        if(Vector2.Angle(Vector2.up,momo.normal) < 20)
						GetComponent<Rigidbody2D>().velocity = new Vector2(rb2d.velocity.x, Vector2.up.y * rb2d.mass);
                    }
                }
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }


    }
}

