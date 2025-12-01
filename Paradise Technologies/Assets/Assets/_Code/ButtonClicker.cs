using UnityEngine;

public class ButtonClicker : MonoBehaviour
{
    private void Update()
    {
        PhysicalButtonClick();
    }

    private void PhysicalButtonClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.Log("Sending raycast from click");

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
            {
                PhysicalButton button = hit.collider.GetComponentInChildren<PhysicalButton>();
                if (button != null)
                {
                    button.ClickButton();
                }
            }
        }
    }
}
