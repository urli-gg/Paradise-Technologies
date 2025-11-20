using UnityEngine;

public class PlayerHandsController : MonoBehaviour
{
    [Header("Manos")]
    public Transform rightHand;
    public Transform leftHand; // opcional

    [Header("Targets para teclas")]
    public Transform keyWTarget;
    public Transform keyATarget;
    public Transform keySTarget;
    public Transform keyDTarget;

    [Header("Configuracion")]
    public float moveSpeed = 10f;
    public Transform idleRightHandTransform; // posición idle opcional

    Transform currentTarget = null;

    void Update()
    {
        // Determinar target según tecla
        if (Input.GetKey(KeyCode.W)) currentTarget = keyWTarget;
        else if (Input.GetKey(KeyCode.A)) currentTarget = keyATarget;
        else if (Input.GetKey(KeyCode.S)) currentTarget = keySTarget;
        else if (Input.GetKey(KeyCode.D)) currentTarget = keyDTarget;
        else currentTarget = idleRightHandTransform != null ? idleRightHandTransform : null;

        // Mover mano derecha suavemente
        if (rightHand != null && currentTarget != null)
        {
            rightHand.position = Vector3.Lerp(rightHand.position, currentTarget.position, Time.deltaTime * moveSpeed);
            rightHand.rotation = Quaternion.Slerp(rightHand.rotation, currentTarget.rotation, Time.deltaTime * moveSpeed);
        }
    }
}

