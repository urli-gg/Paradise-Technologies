using UnityEngine;

public class LockAspectRatio : MonoBehaviour
{
    private int targetWidth = 540;// Ancho deseado de la ventana
    private int targetHeight = 960;//Altura deseada de la ventana

    void Start()
    {
        // Fuerza la resolución inicial
        Screen.SetResolution(targetWidth, targetHeight, false);
    }
}

