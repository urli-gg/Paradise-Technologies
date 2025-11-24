using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButton : MonoBehaviour
{
    [Header("Settings")]
    public float pressDepth = 0.05f;   
    public float Duration = 0.1f;

    public UnityEvent OnButtonClicked;

    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.localPosition;
    }

    public void ClickButton()
    {
        Debug.Log("Physical button clicked!");
        MoveButton();
        OnButtonClicked.Invoke();
    }

    public void MoveButton()
    {
        Sequence bounce = DOTween.Sequence();

        bounce.Append(transform.DOLocalMoveY(_initialPosition.y - pressDepth, Duration))
              .Append(transform.DOLocalMoveY(_initialPosition.y, Duration))
              .SetEase(Ease.OutQuad);
    }
}
