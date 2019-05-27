using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catch_weapon : MonoBehaviour {

    // Use this for initialization
    private bool triggered = false;
    private Collider2D hero;
    private player_shoot shoot;
    public Sprite weapon_skin;
    public SpriteRenderer put_skin;
    public Vector3 target;
    private AudioSource sound;
    public float throwed;
    public AudioClip fire_sound;
    public float ammo;
    public string weapon_name;


    public GameObject weapon_bullet;
	void Start () {
        throwed = -1f;
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (throwed < 0)
        {
			GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.layer = 11;
			if (Input.GetKeyDown(KeyCode.E) && triggered)
			{
				if (!shoot)
				{
					shoot = hero.GetComponent<player_shoot>();
				}
				if (hero.tag == "Player" && !shoot.bullet)
				{
                    Gamemanager.gm.ammo = ammo;
                    Gamemanager.gm.weapon_name = weapon_name;
                    sound.Play();
                    shoot.fire_sound.clip = fire_sound;
					shoot.bullet = weapon_bullet;
					put_skin.sprite = weapon_skin;
					shoot.weapon = this.gameObject;
					transform.position = new Vector3(-30, -30, 0);
				}
			}
        }
	}

	private void FixedUpdate()
	{
        if (throwed > 0)
        {
            gameObject.layer = 12;
            transform.Translate(target * 5 * Time.deltaTime);
            throwed -= Time.deltaTime;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
        hero = collision;
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hero = collision;
        triggered = false;
    }

    public void throw_weapon(Vector3 new_position)
    {
        ammo = Gamemanager.gm.ammo;
        transform.position = new_position;
        target = ((Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position)) - new_position).normalized;
        throwed = 0.5f;
    }
}
