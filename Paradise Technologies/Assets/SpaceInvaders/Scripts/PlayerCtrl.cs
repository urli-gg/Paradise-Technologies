using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour


{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody rb;
    public static int HP = 3;
    
    public int municiones = 0;
    

    public Joystick movementJoystick;

    

    public GameObject bulletPrefab;
    public float bulletSpeed = 15f;
    public GameObject spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
   
        if (PlayerManager.isGameStarted)
        {
            PlayerMove();
            if (Input.GetMouseButton(0))
            {
                JoystickUse();
            }
        }

       
    }



    void PlayerMove()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    }


    void Damage()
    {
        PlayerManager.HP = PlayerManager.HP - 1;
        if (PlayerManager.HP < 1)
        {
            GameOver();
        }
        if (PlayerManager.HP < 1)
        {
            PlayerManager.HP = 0;
        }
        print("CHOQUE" + HP);
    }

    void OnTriggerEnter(Collider objeto)
    {
        if (objeto.transform.tag == "Municion")
        {
            MunitionUp();
        }

        if (objeto.transform.tag == "Obstacle")
        {
            Damage();
        }
    }
    void GameOver()
    {
        print("GAME OVER");
    }

    void MunitionUp()

    {
        PlayerManager.Municiones++;
        municiones = PlayerManager.Municiones;
        print("Municion" + PlayerManager.Municiones);
    }

    private void JoystickUse()
    {
        if(movementJoystick.Direction.y != 0)
        {
            rb.linearVelocity = new Vector2(movementJoystick.Direction.x * movSpeed, movementJoystick.Direction.y * movSpeed);
        }else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    
}
