using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{

    public Ball ball;
    public bool shoot = false;
    // Use this for initialization
    void Start()
    {
        //On positionne le club en fonction de l'emplacement de la balle
        if (ball.transform.localPosition.y < 4.6f)
        {
            transform.position = new Vector3(-0.3f, ball.transform.localPosition.y, 0.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0.15f, 1.33f + ball.transform.localPosition.y, 0.0f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //on Recule la balle en focntion de l'emplacement du club
        if (Input.GetKey(KeyCode.Space) && !ball.fire)
        {
            shoot = false;
            if (ball.transform.localPosition.y < 4.6f)
            {
                    if (ball.power < 100f)
                    transform.Translate(0f, -0.02f, 0f);
            }
            else
            {
                if (ball.power > -100f)
                    transform.Translate(0f, 0.02f, 0f);
            }
        }
        if (ball.fire && !shoot || shoot && !ball.fire)
        {
            if (ball.transform.localPosition.y < 4.6f)
            {
				transform.position = new Vector3(-0.3f, ball.transform.localPosition.y, 0.0f);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.position = new Vector3(0.15f, 1.33f + ball.transform.localPosition.y, 0.0f);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            shoot = true;
        }
    }
}
