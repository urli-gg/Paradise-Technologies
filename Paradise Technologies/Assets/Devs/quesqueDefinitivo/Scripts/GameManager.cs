using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject spaceInvadersRoot; // assign SpaceInvadersGame
    public Transform player;             // assign Player transform
    public Transform lookTarget;         // assign GiantComputer transform
    public GameObject miniMapUI;         // assign MiniMap panel
    public Button playButton;            // assign PlayButton

    bool inMinigame = false;
    Quaternion originalCamRot;
    Vector3 originalCamPos;
    Camera playerCamera;

    void Start()
    {
        if (playButton != null) playButton.onClick.AddListener(StartMinigame);

        if (player != null)
        {
            playerCamera = player.GetComponentInChildren<Camera>();
            if (playerCamera != null)
            {
                originalCamRot = playerCamera.transform.rotation;
                originalCamPos = playerCamera.transform.localPosition;
            }
        }

        if (spaceInvadersRoot != null) spaceInvadersRoot.SetActive(false);
        if (miniMapUI != null) miniMapUI.SetActive(false);
    }

    void Update()
    {
        if (inMinigame && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitMinigame();
        }
    }

    public void StartMinigame()
    {
        if (spaceInvadersRoot != null) spaceInvadersRoot.SetActive(true);
        if (miniMapUI != null) miniMapUI.SetActive(true);
        inMinigame = true;

        if (playerCamera != null && lookTarget != null)
        {
            // mira al objetivo (pantalla)
            playerCamera.transform.LookAt(lookTarget.position);
            // opcional: bloquea la posición local de la cámara
            playerCamera.transform.localPosition = new Vector3(0, 1.6f, 0);
        }

        if (playButton != null) playButton.gameObject.SetActive(false);
        EnableMinigameScripts(true);
    }

    public void ExitMinigame()
    {
        inMinigame = false;
        if (spaceInvadersRoot != null) spaceInvadersRoot.SetActive(false);
        if (miniMapUI != null) miniMapUI.SetActive(false);
        if (playButton != null) playButton.gameObject.SetActive(true);

        if (playerCamera != null)
        {
            playerCamera.transform.localPosition = originalCamPos;
            playerCamera.transform.rotation = originalCamRot;
        }

        EnableMinigameScripts(false);
    }

    void EnableMinigameScripts(bool enable)
    {
        if (spaceInvadersRoot == null) return;
        var comps = spaceInvadersRoot.GetComponentsInChildren<MonoBehaviour>(true);
        foreach (var c in comps) c.enabled = enable;
    }
}
