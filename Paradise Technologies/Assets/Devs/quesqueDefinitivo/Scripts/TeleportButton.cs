using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum TeleportMode { SameScene, OtherScene }

public class TeleportButton : MonoBehaviour
{
    [Header("Visual")]
    public Transform movablePart;          // La pieza superior que baja
    public float pressDepth = 0.02f;
    public float pressTime = 0.08f;

    [Header("Rotulación (opcional)")]
    public TextMeshPro label;
    [TextArea] public string labelText;

    [Header("Acción")]
    public TeleportMode mode = TeleportMode.SameScene;

    [Tooltip("Para SameScene")]
    public Transform sameSceneTarget;      // Empty destino

    [Tooltip("Para OtherScene")]
    public string sceneName;               // Nombre exacto de la escena
    [Tooltip("Para OtherScene: nombre de un spawn en la escena destino (opcional)")]
    public string spawnPointName;

    Vector3 _startLocalPos;
    bool _isBusy;

    void Awake()
    {
        if (movablePart) _startLocalPos = movablePart.localPosition;
        if (label && !string.IsNullOrWhiteSpace(labelText)) label.text = labelText;
    }

    public void Press(GameObject player)
    {
        if (_isBusy) return;
        StartCoroutine(PressRoutine(player));
    }

    IEnumerator PressRoutine(GameObject player)
    {
        _isBusy = true;
        // bajar
        yield return MoveLocalY(movablePart, _startLocalPos.y, _startLocalPos.y - pressDepth, pressTime);
        // acción
        DoAction(player);
        // subir
        yield return MoveLocalY(movablePart, movablePart.localPosition.y, _startLocalPos.y, pressTime);
        _isBusy = false;
    }

    void DoAction(GameObject player)
    {
        var tele = player.GetComponent<PlayerTeleporter>();
        if (!tele) { Debug.LogWarning("PlayerTeleporter no encontrado en el Player."); return; }

        if (mode == TeleportMode.SameScene)
        {
            if (sameSceneTarget == null) { Debug.LogWarning("sameSceneTarget no asignado."); return; }
            tele.TeleportToTransform(sameSceneTarget);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(sceneName)) { Debug.LogWarning("sceneName vacío."); return; }
            tele.TeleportToScene(sceneName, spawnPointName);
        }
    }

    IEnumerator MoveLocalY(Transform t, float from, float to, float time)
    {
        if (!t) yield break;
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float k = Mathf.Clamp01(elapsed / time);
            float y = Mathf.Lerp(from, to, k);
            t.localPosition = new Vector3(t.localPosition.x, y, t.localPosition.z);
            yield return null;
        }
    }

    void OnValidate()
    {
        if (label != null) label.text = labelText;
    }
}
