using UnityEngine;

public class BotonFisico : MonoBehaviour
{
    public BottleSpawner bottleSpawner; 

    private void OnMouseDown()
    {
       
        bottleSpawner.canSpawn = !bottleSpawner.canSpawn;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            bottleSpawner.canSpawn = !bottleSpawner.canSpawn;
        }
    }

}
