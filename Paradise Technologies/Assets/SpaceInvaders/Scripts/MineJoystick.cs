using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineJoystick : MonoBehaviour
{
   public Joystick moveJoystick;
    public float movSpeed;
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        if(moveJoystick.Direction.y != 0) 
        {
            rb.linearVelocity = new Vector2(moveJoystick.Direction.x * movSpeed, moveJoystick.Direction.y * movSpeed);
        }else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
