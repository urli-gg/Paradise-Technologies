using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontrol : MonoBehaviour
{
    public GameObject spawnPoint;
    
    public TMPro.TextMeshProUGUI GameMunitions;
    
    public int municiones = PlayerManager.Municiones;
    public GameObject bulletPrefab;
    public float bulletSpeed = 15f;

    public GameObject vidas3;
    public GameObject vidas2;
    public GameObject vidas1;

    public GameObject win;
    public GameObject changeScene;
    public GameObject changeScene2;
    public GameObject finalWin;

    public GameObject portada;

    public GameObject startButton;

    public GameObject blanco1;
    public GameObject blanco2;
    public GameObject blanco3;

    public GameObject levSelect;
    public GameObject credits;
    public GameObject replay;
    public GameObject quit;

    public AudioSource audioSource;

    

    Rigidbody rb;

    public void Start()
    {
        win.SetActive(false);
        changeScene.SetActive(false);
        changeScene2.SetActive(false);
        finalWin.SetActive(false);
        blanco2.SetActive(false);
        blanco3.SetActive(false);
    }

    public void Update()
    {
        GameMunitions.text = PlayerManager.Municiones.ToString();
        municiones = PlayerManager.Municiones;
        if (PlayerManager.isGameStarted)
        {
            if (PlayerManager.HP <= 0)
            {
                GameOver();
            }
        }
        if (PlayerManager.HP < 0)
        {
            PlayerManager.HP = 0;
        }

        if (PlayerManager.HP < 3)
        {
            vidas3.SetActive (false);
        }
        if (PlayerManager.HP < 2)
        {
            vidas2.SetActive (false);
        }
        if (PlayerManager.HP < 1)
        {
            vidas1.SetActive (false);
        }

        if (PlayerManager.BossHP == 0)
        {
            Win();
        }

        if (PlayerManager.isGameStarted)
        {
            portada.SetActive(false);
            replay.SetActive(false);
            
        }

        BlancosSet();
    }

    public void StartGame()
    {
        PlayerManager.isGameStarted = true;
        rb = GetComponent<Rigidbody>();
        portada.SetActive(false);
        startButton.SetActive(false);
        blanco1.SetActive(true);
        credits.SetActive(false);
        levSelect.SetActive(false);
        replay.SetActive(false);
        audioSource = GetComponent<AudioSource>();

    }

    public void BlancosSet()
    {
        if (PlayerManager.BossHP <= 6)
        {
            blanco1.SetActive (false);
        }

        if (PlayerManager.BossHP == 6)
        {
            blanco2.SetActive(true);
        }
        if (PlayerManager.BossHP <= 3)
        {
            blanco2.SetActive(false);
        }

        if (PlayerManager.BossHP == 3)
        {
            blanco3.SetActive(true);
        }

        if (PlayerManager.BossHP <= 0)
        {
            blanco3.SetActive(false);
        }
    }

    public void Win()
    {
        if (PlayerManager.BossHP < 1)
        {
            win.SetActive(true);

            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                changeScene.SetActive(true);
            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                changeScene2.SetActive(true);
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                finalWin.SetActive(true);
                replay.SetActive(true);
            }
            PlayerManager.isGameStarted = false;
            PlayerManager.levelUp = true;

            LevelUp();
        }
    }

    public void LevelUp()
    {
        //PlayerManager.levelUp = true; 
        PlayerManager.isGameStarted = false;

        if (PlayerManager.levelUp)
        {
            PlayerManager.Municiones = 0;
            GameMunitions.text = "0";
            PlayerManager.HP = 3;
            PlayerManager.BossHP = 8;
            startButton.SetActive(false);
        }

        /*win.SetActive(false);
        changeScene.SetActive(false);*/
    }

    public void Shoot()
    {
       
        if (PlayerManager.isGameStarted)
        {
            if (PlayerManager.Municiones >= 1)
            {
                var bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                bullet.GetComponent<Rigidbody>().linearVelocity = spawnPoint.transform.forward * bulletSpeed;

                PlayerManager.Municiones--;
            }

        }
        Debug.Log("Municiones antes de disparar: " + municiones);

    }



    public void gameNotStarted()
    {
        PlayerManager.isGameStarted = false;
    }
    public void GameOver()
    {
        PlayerManager.isGameStarted = false;
        Reset();
    }

    public void Reset()
    {
        PlayerManager.Municiones = 0;
        GameMunitions.text = "0";
        PlayerManager.HP = 3;
        PlayerManager.BossHP = 8;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    
    

}
