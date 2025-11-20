using UnityEngine;

public class BotonFisico : MonoBehaviour
{
    public ConveyorBelt conveyorBelt;

    private void OnMouseDown()
    {
        
        conveyorBelt.enabled = !conveyorBelt.enabled;
    }
}
