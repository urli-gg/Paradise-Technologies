using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
    public Transform moveTarget;
    public float moveDuration = 10f;
    public FirstPersonController playerController;

    private bool isMoving = false;
    private Vector3 startPos;
    private float timer = 0f;
    private Transform playerOriginalParent;

    void Start()
    {
        startPos = transform.position;
    }

    public void StartBoatRide()
    {
        if (!isMoving)
            StartCoroutine(MoveBoat());
    }

    IEnumerator MoveBoat()
    {
        isMoving = true;

        // Desactiva movimiento del jugador, pero no la cámara
        playerController.canMove = false;

        // Guarda su padre original y lo hace hijo del barco
        playerOriginalParent = playerController.transform.parent;
        playerController.transform.SetParent(transform);

        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            float t = timer / moveDuration;
            transform.position = Vector3.Lerp(startPos, moveTarget.position, t);
            yield return null;
        }

        // Termina el viaje
        playerController.canMove = true;

        // Restaura el padre original del jugador
        playerController.transform.SetParent(playerOriginalParent);

        isMoving = false;
        timer = 0f;
    }
}
