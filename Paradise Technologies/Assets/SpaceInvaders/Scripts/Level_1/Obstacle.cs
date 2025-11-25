using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float MovSpeed = -1;
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
}
