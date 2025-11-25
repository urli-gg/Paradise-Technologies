using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition3 : MonoBehaviour
{
    public float MovSpeed = -6;
    public float MovSpeedX = -2f;
    //public GameObject munition; 

    void Update()

    {
        if (PlayerManager.isGameStarted)
        {
            TransportYPos();
            TransportXPos();
        }
    }
    public void TransportYPos()
    {
        transform.Translate(0, MovSpeed * Time.deltaTime, 0);
    }

    public void TransportXPos()
    {
        transform.Translate(MovSpeedX * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider munition)
    {
        if (munition.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
        //Destroy(objeto.gameObject);
    }


}
