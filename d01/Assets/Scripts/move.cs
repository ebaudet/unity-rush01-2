using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    private float time = 0f;
    public bool left = true;
    public bool vertical = false;
    public float duration;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
		if (time > duration)
		{
			time = 0;
			left = !left;
		}
        if (vertical)
        {
            if (left)
            {
                transform.Translate(0f,-Time.deltaTime, 0f);
            }
            else
            {
                transform.Translate(0f,Time.deltaTime, 0f);
            }
        }
        else
        {
            if (left)
            {
                transform.Translate(-Time.deltaTime, 0f, 0f);
            }
            else
            {
                transform.Translate(Time.deltaTime, 0f, 0f);
            }
        }

    }
}
