using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    //public GameObject win;
    //public GameObject changeScene;

    public GameObject boss1;
    public GameObject boss2;
    public GameObject boss3;
    public GameObject boss4;
    public GameObject boss5;
    public GameObject boss6;
    public GameObject boss7;
    public GameObject boss8;
    //public GameObject boss9;

    private void Update()
    {
        /*if (PlayerManager.BossHP == 0)
        {
            Win();
        }*/

        if (PlayerManager.BossHP < 8)
        {
            boss1.SetActive(false);
        }
        if (PlayerManager.BossHP < 7)
        {
            boss2.SetActive(false);
        }
        if (PlayerManager.BossHP < 6)
        {
            boss3.SetActive(false);
        }
        if (PlayerManager.BossHP < 5)
        {
            boss4.SetActive(false);
        }
        if (PlayerManager.BossHP < 4)
        {
            boss5.SetActive(false);
        }
        if (PlayerManager.BossHP < 3)
        {
            boss6.SetActive(false);
        }
        if (PlayerManager.BossHP < 2)
        {
            boss7.SetActive(false);
        }
        if (PlayerManager.BossHP < 1)
        {
            boss8.SetActive(false);
        }

    }
    /*private void Start()
    {
        if (PlayerManager.BossHP >= 1)
       {
            win.SetActive(false);
        changeScene.SetActive(false);
       }

    }*/
    void OnTriggerEnter(Collider objeto)
    {
        print("Mensaje");
        if (objeto.transform.tag == "Bullet")
        {
            Damage();
        }
    }
    void Damage()
    {
        //PlayerManager.BossHP = PlayerManager.BossHP - 1;
        
        PlayerManager.BossHP--;
        print("CHOQUE" + PlayerManager.BossHP);
    }

    /*void Win()
    {
        if(PlayerManager.BossHP < 1)
        {
            win.SetActive(true);
            changeScene.SetActive(true);
            PlayerManager.isGameStarted = false;
        }
    }*/

    public void ChangeScene(string level_2)
    {
    
        SceneManager.LoadScene(level_2);
    
    }
}

