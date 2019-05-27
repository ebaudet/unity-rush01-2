using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player : MonoBehaviour {

    public enum Dir
    {
        stay,
        forward,
        righttop,
        right,
        rightbot,
        bot,
    }

    public float speed = 1.5f;
    public Sprite[] sprites;
    public AudioClip[] audios;
    public bool selected = true;
    public bool reset;
    public bool over;
    public bool attack = false;
    public float tolerance;

    private Vector3 target;
    private Rigidbody2D rb2d;
    private bool iswalking = false;
    private Animator animator;
    private SpriteRenderer sprite;
    private float dirx = 0f;
    private float diry = 0f;
    private int apply = 3;
    private AudioSource audioSource;


    void Start () {
        GameController.instance.humans.Add(this);
        target = transform.position;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        reset = true;
    }



	private void LateUpdate()
	{
        if (!iswalking)
        {
			sprite.sprite = sprites[apply];
        }
		
	}

    void OnMouseOver()
    {
        over = false;
        if (Input.GetMouseButtonDown(0) && tag == "Player")
        {
            over = true;
            if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl) && GameController.instance.selected_human != 0)
            {
                reset = false;
                selected = true;
                GameController.instance.reset();
            }
            else if (!selected)
                selected = true;
            else
                reset = true;
        }
    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selected = false;
        }
        if (!iswalking)
        {
            //rb2d.mass = 1;
            rb2d.simulated = true;
            target = transform.position;
        }
        if (selected && !over)
        {
            
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
            {
                if (GameController.instance.whereismouse.Contains("orc"))
                    attack = true;
                else
                    attack = false;
                audioSource.PlayOneShot(audios[Random.Range(0, audios.Length)]);
                set_animation_target();
            }
        }
        //Deplacement
        if (iswalking)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (rb2d.bodyType != RigidbodyType2D.Dynamic)
                rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
        if (target == transform.position && iswalking)
        {
            iswalking = false;
            animator.SetInteger("direction", (int)Dir.stay);
        }
    } 

    //Choix de l'animation en fonction de la direction
    void set_animation_target()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        iswalking = true;
        //rb2d.simulated = false;
        //rb2d.mass = 30;
        dirx = target.x - transform.position.x;
        diry = target.y - transform.position.y;

        if (dirx > 0)
        {
            if (sprite.flipX)
                sprite.flipX = false;
        }
        if (dirx < 0)
        {
            if (!sprite.flipX)
                sprite.flipX = true;
        }
            if (diry > 0)
            {
                if (0.66 * Mathf.Abs(dirx) > diry)
                {
                    animator.SetInteger("direction", (int)Dir.right);
                    apply = 2;
                }

                else if (0.66 * diry > Mathf.Abs(dirx))
                {
                    animator.SetInteger("direction", (int)Dir.forward);
                    apply = 0;
                }
                else
                {
                    animator.SetInteger("direction", (int)Dir.righttop);
                    apply = 1;
                }
            }
            if (diry < 0)
            {
                if (0.66 * Mathf.Abs(dirx) > -diry)
                {
                    animator.SetInteger("direction", (int)Dir.right);
                    apply = 2;
                }
                else if (-0.66 * diry > Mathf.Abs(dirx))
                {
                    animator.SetInteger("direction", (int)Dir.bot);
                    apply = 4;
                }
                else
                {
                    animator.SetInteger("direction", (int)Dir.rightbot);
                    apply = 3;
                }
            }
    }
}
