using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class BoatMover : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField, Required] private GameObject _player;
    [SerializeField, Required] private Transform _boatSeat;

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _sinAmplitude = 1f;

    public UnityEvent OnStartedMoving;
    public UnityEvent OnReachedDestination;

    private Vector3 startLocalPos;
    private float t = -Mathf.PI / 2;
    private bool canMove = false;
    private bool goingUp = true;

    void Start()
    {
        startLocalPos = transform.localPosition;
        transform.localPosition = startLocalPos + new Vector3(0f, 0f, -_sinAmplitude);
    }

    void FixedUpdate()
    {
        if (!canMove) return;

        t += Time.fixedDeltaTime * _moveSpeed * (goingUp ? 1 : -1);
        float xOffset = Mathf.Sin(t) * _sinAmplitude;
        transform.localPosition = startLocalPos + new Vector3(0f, 0f, xOffset);
        _player.transform.localPosition = new Vector3(0f, 0f, 0f);

        if (goingUp && xOffset >= _sinAmplitude - 0.001f)
        {
            goingUp = false;
            canMove = false;
            OnReachedDestination?.Invoke();
            EnablePlayer();
        }
        else if (!goingUp && xOffset <= -_sinAmplitude + 0.001f)
        {
            goingUp = true;
            canMove = false;
            OnReachedDestination?.Invoke();
            EnablePlayer();
        }
    }

    [Button]
    public void StartMoving()
    {
        OnStartedMoving?.Invoke();
        DisablePlayer();
        canMove = true;
    }

    private void DisablePlayer()
    {
        _player.transform.position = _boatSeat.position;
        _player.transform.parent = this.transform;
    }

    private void EnablePlayer()
    {
        _player.transform.transform.parent = null;
    }
}
