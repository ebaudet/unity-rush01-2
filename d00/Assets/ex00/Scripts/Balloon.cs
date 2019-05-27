using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float scale = 0.5f;
    public float degonfle = 1.2f;
    private float air = 100f;
    private float time = 0f;
    private bool go = false;
    private float noair = 0f;

    // Update is called once per frame
    void Update()
    {
        //start game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            go = true;
        }
        //boucle du jeu
        if (go)
        {
            time += Time.deltaTime;
            // fin du jeu 120s
            if (Mathf.RoundToInt(time) == 120)
            {
                Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
                GameObject.Destroy(gameObject);
            }
            //on gonfle si on a + 20 air
            if (Input.GetKeyDown(KeyCode.Space) && air > 0)
            {
                transform.localScale += new Vector3(scale, scale, 0);
                air -= 15;
                // si trop gros detruit
                if (transform.localScale.x > 7.3f)
                {
                    Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
                    GameObject.Destroy(gameObject);
                }
            }
            else
            {
                //degonfle ou detruit si trop petit
                if (transform.localScale.x > 0.3f)
                {
                    transform.localScale -= new Vector3(degonfle * Time.deltaTime, degonfle * Time.deltaTime, 0);
                }
                else
                {
                    Debug.Log("Balloon life time: " + Mathf.RoundToInt(time) + "s");
                    GameObject.Destroy(gameObject);
                }

                //On gere le souffle, si plus d'air on attend 2s pour recuperer 40
                if (air < 100)
                {
                    if (air > 0)
                    {

                        air += 50f * Time.deltaTime;
                        if (noair != 0)
                        {
                            noair = 0;
                        }
                    }
                    else
                    {
                        noair += Time.deltaTime;
                        if (noair > 2)
                        {
                            air = 40;
                        }
                    }
                }
            }
        }
    }
}
