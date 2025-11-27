using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class MenuController : MonoBehaviour
{
    public Transform[] menuObjects;
    public int index = 0;
    public float rotationAmount = 72f;
    public float timeToRotate = 1f;

    [Button]
    public void RotateRight()
    {
        transform.DORotate(new Vector3(0, rotationAmount, 0), timeToRotate, RotateMode.LocalAxisAdd);
        index++;
        if (index >= menuObjects.Length) index = 0;
    }

    [Button]
    public void RotateLeft()
    {
        transform.DORotate(new Vector3(0, -rotationAmount, 0), timeToRotate, RotateMode.LocalAxisAdd);
        index--;
        if (index < 0) index = menuObjects.Length - 1;
    }

    public int GetCurrentIndex()
    {
        return index;
    }

    public string GetCurrentObjectName()
    {
        return menuObjects[index].name;
    }
}
