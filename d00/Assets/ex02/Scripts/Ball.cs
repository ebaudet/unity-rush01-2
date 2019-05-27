using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool fire = false;
    private bool win = false;
    public float power = 0f;
    private float score = -15f;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0.0f, -3f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {

        //Balle dans le trou
        if (transform.localPosition.y > 4.44f && transform.localPosition.y < 4.6f && power < 20 && power > -20 && win == false)
        {
           // Debug.Log("Gagne !");
            win = true;
        }
        if(!win)
        {
            // On charge notre coup
            if (Input.GetKey(KeyCode.Space) && !fire)
            {
					power = Mathf.Clamp((power + (Time.deltaTime * 50)), 10f, 100f);
            }
            else
            {
                if (power < -10 || power > 10)
                {
                    // le coup part on incremente le score et verifie si on tire vers le haut ou le bas
                    if (!fire)
                    {
                        if (transform.localPosition.y > 4.6f)
                            power = -power;
						fire = true;
                        score += 5f;
                        Debug.Log("score: " + score);
                    }
                    // shoot vers le haut
                    if (power > 0)
                    {
                        if ((transform.localPosition.y + (power / 100f)) >= 5.5f)
                        {
                            transform.Translate(0, (5.5f - transform.localPosition.y), 0);
                            power -= (Time.deltaTime * 50);
                            power = -power;
                        }
                        else
                        {
                            transform.Translate(0, power / 100f, 0);
                            power -= (Time.deltaTime * 50);
                        }
                    }
                    //Shoot vers le bas
                    if (power < 0)
                    {
                        if ((transform.localPosition.y + (power / 100f)) <= -3.51f)
                        {
                            transform.Translate(0, -(transform.localPosition.y + 3.51f), 0);
                            power += (Time.deltaTime * 50);
                            power = -power;
                        }
                        else
                        {
                            transform.Translate(0, power / 100f, 0);
                            power += (Time.deltaTime * 50);
                        }
                    }

                }
                //balle stoppe on peut de nouveau tirer
                else
                {
                    power = 0;
                    fire = false;
                }
            }
        }


	}
}
