using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void StartGame()
    {
        PlayerManager.isGameStarted = true;
        /*rb = GetComponent<Rigidbody>();
        portada.SetActive(false);
        startButton.SetActive(false);
        blanco1.SetActive(true);*/

    }

    // Start is called before the first frame update
    public void LoadLevSelect()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(4);

    }
    public void LoadLev1()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
        
     public void LoadLev2()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

    }
    public void LoadLev3()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

    }

    public void Replay()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }
    public void Credits()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(5);

    }

    public void Home()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }




            public void QuitGame()
    {
#if UNITY_EDITOR
        // Detener el modo de juego en el editor de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Cerrar la aplicación en una build
        Application.Quit();
#endif

        // Mensaje de depuración
        Debug.Log("Se ha activado QuitGame. Saliendo...");
    }
}