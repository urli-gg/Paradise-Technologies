using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    public float MovSpeed = -2;
    //public GameObject munition; 

    void Update()

    {
        if (PlayerManager.isGameStarted)
        {
            TransportYPos();
        }
    }
    public void TransportYPos()
    {
        transform.Translate(0, MovSpeed * Time.deltaTime, 0);
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
