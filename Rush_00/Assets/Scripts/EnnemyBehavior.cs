using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBehavior : MonoBehaviour {

    public Transform player;
	public GameObject bullet;
    public Transform bullet_spawn;
    public float vision;
    public float range;
    public float soundrange;
    public float speed;
    public float fire_rate;
    public Animator walk;
    public bool patrouille;
    public Transform spot1;
    public Transform spot2;
	public bool ischasing = false;
    public LayerMask mask;
    public bool insight = false;
    public float max_chase_time;
    public float back_vision;
    public GameObject[] doors = null;
    public Vector3 door_togo;
    public Vector3 to_go;


    private bool reach1 = false;
    private float vision_origin;
    private float time = 0;
    private float chase_time;
    private Vector3 last_pos;

    private SpriteRenderer sprite;
    private SpriteRenderer[] legs;
	// Use this for initialization
	void Start () {
        last_pos = Vector3.zero;
        door_togo = Vector3.zero;
        sprite = GetComponent<SpriteRenderer>();
        vision_origin = vision;
        time = fire_rate;
        legs = GetComponentsInChildren<SpriteRenderer>();
        Gamemanager.gm.nbr_ennemy += 1;
        doors = GameObject.FindGameObjectsWithTag("Portes");
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (player != null)
        {
           
        if (Gamemanager.gm.fire)
        {
            vision = soundrange;
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) > Vector3.Distance(bullet_spawn.position, player.position))
                vision = vision_origin;
            else
                vision = back_vision;
        }
        time += Time.deltaTime;
        chase_time += Time.deltaTime;
        if (chase_time > max_chase_time)
        {
            ischasing = false;
            chase_time = 0;
            walk.SetBool("walking", false);
        }
		 RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.position - transform.position).normalized, Mathf.Infinity, mask);
            if (hit)
            {
                if (hit.collider.tag == "Player")
                {
					insight = true;
                    last_pos = hit.collider.transform.position;
                }

                else
                    insight = false;

            }
            if ((Vector3.Distance(transform.position, player.position) <= vision && (insight || Gamemanager.gm.fire)) || ischasing)
            {
                ischasing = true;
                transform.up = -(player.position - transform.position);
                if (Vector3.Distance(transform.position, player.position) > range || !insight)
                {
                    foreach (var door in doors)
                    {
                        if (Vector3.Distance(door.transform.position, player.position) < Vector3.Distance(door_togo, player.position))
                        {
                            door_togo = door.transform.position;
                        }
                    }
                    if (Vector3.Distance(door_togo, player.position) < Vector3.Distance(last_pos, player.position))
                    {
                        to_go = door_togo;
                    }
                    else
                    {
                        to_go = last_pos;
                    }
                    transform.position = Vector3.MoveTowards(transform.position, to_go, speed * Time.deltaTime);
                    walk.SetBool("walking", true);
                }
                else
                {
                    walk.SetBool("walking", false);
                    if (time >= fire_rate)
                    {
                        chase_time = 0;
                        Ennemy_fire();
                        time = 0;
                    }
                }
            }
            if (patrouille && !ischasing)
            {
                patrouille_boucle();
            }
        }
        else
            walk.SetBool("walking", false);

	}


    public void Ennemy_fire()
    {
        bullet_spawn.localPosition = new Vector3(bullet_spawn.localPosition.x,bullet.GetComponent<Bullet_script>().offset,0);
        GameObject bulletclone = Instantiate(bullet, bullet_spawn.position, bullet_spawn.rotation);
        bulletclone.GetComponent<Bullet_script>().player_position = player.position;
    }

    public void patrouille_boucle()
    {
        walk.SetBool("walking", true);
        if (Vector3.Distance(transform.position, spot1.position) < 0.05 && reach1)
        {
            reach1 = false;
            transform.up = -(spot2.position - transform.position);
        }
        if (Vector3.Distance(transform.position, spot2.position) < 0.05 && !reach1)
        {
            reach1 = true;
            transform.up = -(spot1.position - transform.position);
        }
        if (reach1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spot1.position, speed * Time.deltaTime);
        }
        if (!reach1)
        {
            transform.position = Vector3.MoveTowards(transform.position, spot2.position, speed * Time.deltaTime);
        }
    }

}
