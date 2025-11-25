using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerabilidad_Rot : MonoBehaviour
{
    private float RotSpeed = 15;

    void Update()
    {
        if (PlayerManager.isGameStarted)
        {
            RotateModelZ();
        }
        
    }

    public void RotateModelZ()
    {
    
        this.transform.Rotate(0, 0, RotSpeed * Time.deltaTime);
        
    }
}
