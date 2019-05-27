using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour {

    public float MovementSpeed;
    public Animator leg;
    private bool power = false;
    public SpriteRenderer sprite_head;
    public SpriteRenderer sprite_leg;
    public SpriteRenderer sprite_body;

	private void Start()
	{
	}
	void FixedUpdate()
    {
        if (Gamemanager.gm.unkillable)
        {
            sprite_head.color = new Color(255, 255, 0, 255);
            sprite_body.color = new Color(255, 255, 0, 255);
            sprite_leg.color = new Color(255,255 ,0 , 255);
        }
        else
        {
            if (sprite_head.color != new Color(255,255,255,255))
            {
                sprite_head.color = new Color(255, 255, 255, 255);
                sprite_body.color = new Color(255, 255, 255, 255);
                sprite_leg.color = new Color(255, 255, 255, 255);
            }
        }
        Vector3 direction = CalculateDirection();
        if (direction != Vector3.zero)
        {
            leg.SetBool("walking", true);
        }
        else
        leg.SetBool("walking", false);
        transform.Translate(direction * MovementSpeed * Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player_shoot");
        }
        if (Input.GetKeyDown(KeyCode.Q) && !power)
        {
            power = true;
            Gamemanager.gm.unkillable = true;
        }

    }

    public Vector3 CalculateDirection()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            direction.y += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction.x -= 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            direction.y -= 1.0f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction.x += 1.0f;
        }
        return direction.normalized;
    }
}
