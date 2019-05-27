using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public bool go = false;
    public float jump;
    public float fall;
    private bool end = false;
    public Transform pipe_1;
    public Transform pipe_2;
    public Pipe pipe_1s;
    public Pipe pipe_2s;
    private float time = 0;
    private float score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //recommencer
        if (end)
        {
            time = 0;
            score = 0;
            pipe_1s.score = 0;
            pipe_2s.score = 0;
            go = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                end = false;
                transform.Translate(0,-transform.localPosition.y,0);
                pipe_1.transform.Translate(-pipe_1.transform.localPosition.x + 6, 0, 0);
                pipe_2.transform.Translate(-pipe_2.transform.localPosition.x + 12, 0, 0);
            }
        }
        //start game
        if (!end)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                go = true;
            }

            //Boucle de jeu
            if (go)
            {
                time += Time.deltaTime;
                if ((transform.localPosition.x - pipe_1.localPosition.x < 1.35 && transform.localPosition.x - pipe_1.localPosition.x > -1.35)||(transform.localPosition.x - pipe_2.localPosition.x < 1.35 && transform.localPosition.x - pipe_2.localPosition.x > -1.35))
                {
                    if (transform.localPosition.y > 1.23f || transform.localPosition.y < -1.62f)
                    {
                        end = true;
                        score = pipe_1s.score + pipe_2s.score;
                        Debug.Log("Score: " + score);
                        Debug.Log("Time: " + Mathf.RoundToInt(time) + "s");
                    }
                }
                if (transform.localPosition.y < -2.84f)
                {
                    end = true;
                    score = pipe_1s.score + pipe_2s.score;
                    Debug.Log("Score: " + score);
                    Debug.Log("Time: " + Mathf.RoundToInt(time));
                }
                if(!end)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        transform.Translate(0f, jump, 0f);
                    }
                    else
                    {
                        transform.Translate(0f, -Time.deltaTime * fall, 0f);
                    }
                }
            }
        }
	}
}
