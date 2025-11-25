using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    public float MovSpeed = -1;
    public float MovSpeedX = 0.5f;

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

    /*void Destroy()
    {
        Destroy(GameObject, 13f);
    }*/
}
