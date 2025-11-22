using UnityEngine;
using System.Collections;

public class BoatRide : MonoBehaviour
{
    public Transform moveTarget;             // Punto final del barco
    public float moveDuration = 10f;         // Tiempo que dura el viaje

    public FirstPersonController playerController; // Referencia al Player
    private bool isMoving = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving && other.CompareTag("Player"))
        {
            StartCoroutine(MoveBoat(other.transform));
        }
    }

    IEnumerator MoveBoat(Transform player)
    {
        isMoving = true;

        // Desactiva el movimiento del jugador pero permite rotar cámara
        playerController.canMove = false;

        // Calcula la diferencia inicial entre jugador y barco
        Vector3 offset = player.position - transform.position;

        float timer = 0f;
        while (timer < moveDuration)
        {
            timer += Time.deltaTime;
            float t = timer / moveDuration;

            // Mueve el barco
            transform.position = Vector3.Lerp(startPos, moveTarget.position, t);

            // Mantén al jugador arriba del barco usando el offset
            player.position = transform.position + offset;

            yield return null;
        }

        // Fin del viaje
        playerController.canMove = true;
        isMoving = false;
    }
}
