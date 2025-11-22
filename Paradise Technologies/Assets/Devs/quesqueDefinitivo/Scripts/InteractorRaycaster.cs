using UnityEngine;
using UnityEngine.InputSystem; // Input System nuevo

public class InteractorRaycaster : MonoBehaviour
{
    [SerializeField] float maxDistance = 3f;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            var cam = Camera.main;
            if (!cam) return;

            //  Ray desde la posición del puntero en pantalla
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                var button = hit.collider.GetComponentInParent<TeleportButton>();
                if (button != null)
                {
                    var player = GameObject.FindGameObjectWithTag("Player");
                    if (player != null) button.Press(player);
                }
            }
        }
    }
}
