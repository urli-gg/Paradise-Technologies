using UnityEngine;

public class Wheel : MonoBehaviour
{
   public WheelCollider wheelCollider;
    public Transform wheelmesh;
    public bool wheelTurn;

    
    void Update()
    {
        if(wheelTurn == true)
        {
            wheelmesh.localEulerAngles = new Vector3(wheelmesh.localEulerAngles.x, wheelCollider.steerAngle - transform.parent.localEulerAngles.y, wheelmesh.localEulerAngles.z);
        }
        wheelmesh.Rotate(wheelCollider.rpm / 60 * 360 * Time.deltaTime, 0, 0);
    }
}
