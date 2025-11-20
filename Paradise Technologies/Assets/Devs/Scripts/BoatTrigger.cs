using UnityEngine;

public class BoatTrigger : MonoBehaviour
{
    public BoatController boat;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boat.StartBoatRide();
        }
    }
}
