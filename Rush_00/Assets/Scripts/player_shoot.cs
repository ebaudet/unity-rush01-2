using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public GameObject weapon;
    public SpriteRenderer weapon_skin;
    public AudioSource fire_sound;


    public AudioSource dry;
    public Transform bullet_spawn;
    public Camera cam;
    public float time;
	void Start () {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (bullet)
        {
            time += Time.deltaTime;
            if (time >= bullet.GetComponent<Bullet_script>().fire_rate)
            {
                if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)))
                {
                    if(Gamemanager.gm.ammo > 0 || Gamemanager.gm.ammo < 0)
                    {
                        fire();
                        Gamemanager.gm.ammo -= 1;
                        time = 0;
                    }
                    else
                    {
                        time = 0;
                        dry.Play();
                    }
                }
                else
                    Gamemanager.gm.fire = false;
            }
            else
            {
                Gamemanager.gm.fire = false;
            }
            if (Input.GetMouseButtonDown(1))
            {
                weapon.GetComponent<catch_weapon>().throw_weapon(transform.position);
                Gamemanager.gm.weapon_name = "No weapon";
                bullet = null;
                weapon = null;
                weapon_skin.sprite = null;
                fire_sound.clip = null;
            }
        }
	}

    public void fire()
    {
        fire_sound.Play();
        Gamemanager.gm.fire = true;
        bullet_spawn.localPosition = new Vector3(bullet_spawn.localPosition.x, bullet.GetComponent<Bullet_script>().offset, 0);
        GameObject bulletclone = Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation);
        bulletclone.GetComponent<Bullet_script>().player_position = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        bulletclone.GetComponent<Bullet_script>().hero = true;
    }
}
