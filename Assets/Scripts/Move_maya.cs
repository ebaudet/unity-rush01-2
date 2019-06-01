using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move_maya : MonoBehaviour {


    public Animator animator;
    public float atk_range;
    public string tag;
    public bool isazombie;

    public int STR;
    public int AGI;
    public int CON;
	public int ARMOR;
    public float hp;
    public float minDMG;
    public float maxDMG;
    public float baseDMG;
    public int level;
    public int xp;
    public int money;
    public int xpForNext;
    public int stats_point;



    private NavMeshPath path;
	private NavMeshAgent nav;
    private Transform target;
    public RaycastHit hit;
    public Zombie_scripts zombie_stats;
    public GameObject die_panel;

	// Use this for initialization
	void Start () {
        isazombie = false;
        target = null;
        nav = GetComponent<NavMeshAgent>();
        CON = 15;
        AGI = 10;
        STR = 8;
        ARMOR = 20;
        level = 1;
        xp = 0;
        xpForNext = 100;
        money = 0;
        stats_point = 0;

        set_stats();
	}

    public void plus_for()
    {
        STR += 1;
        stats_point -= 1;
        set_stats();
    }

    public void plus_CON()
    {
        stats_point -= 1;
        CON += 1;
        set_stats();
    }

    public void plus_AGI()
    {
        stats_point -= 1;
        AGI += 1;
        set_stats();
    }

    void set_stats()
    {
        hp = 5 * CON;
        minDMG = STR / 2;
        maxDMG = minDMG + 4;
    }
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            if (tag == "zombie")
            {
                nav.SetDestination(target.position);

            }
            else
                nav.SetDestination(hit.point);
            if (Vector3.Distance(transform.position, target.position) < atk_range && tag == "zombie" && target.GetComponent<Zombie_scripts>().hp > 0)
            {
                nav.SetDestination(transform.position);
                transform.forward = target.position - transform.position;
                animator.SetInteger("State", 2);
            }
            else
            {
    			if (nav.hasPath)
    			{
    				animator.SetInteger("State", 1);
    			}
    			else
    			{
    				animator.SetInteger("State", 0);
    			}
            }
            if (target.GetComponent<Zombie_scripts>() && target.GetComponent<Zombie_scripts>().hp <= 0)
            {
                nav.SetDestination(transform.position);
            }
        }
        if (Input.GetMouseButton(0) && !isazombie)
        {
            move();
        }
        if (Input.GetMouseButtonUp(0))
            isazombie = false;
        if (hp <= 0)
        {
            animator.SetInteger("State", 3);
            die_panel.SetActive(true);
            this.enabled = false;
        }
	}

    public void move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, float.PositiveInfinity))
        {
            target = hit.collider.transform;
            tag = hit.collider.tag;
            if (tag == "zombie")
            {
                zombie_stats = target.GetComponent<Zombie_scripts>();
				isazombie = true;
            }
        }
    }

    public void attack()
    {
        if (Random.Range(0,100) < (75 + AGI - zombie_stats.AGI))
        {
            zombie_stats.hp -= (int) (Random.Range(minDMG,maxDMG) *(1 - zombie_stats.ARMOR / 200));
            Debug.Log((int)(Random.Range(minDMG, maxDMG) * (1 - zombie_stats.ARMOR / 200)));
            if (zombie_stats.hp <= 0)
            {
                xp += zombie_stats.xp;
                money += zombie_stats.money;
                if (xp >= xpForNext)
                {
                    xp -= xpForNext;
                    level += 1;
                    stats_point += 5;
                    xpForNext = (int)(xpForNext * 1.5);
                    set_stats();
                }
            }
        }
    }
}
