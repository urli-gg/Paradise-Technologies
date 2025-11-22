using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTeleporter : MonoBehaviour
{
    public static string PendingSpawnPointName = null;
    CharacterController _cc;

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
        DontDestroyOnLoad(gameObject); // Conserva al Player al cambiar de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TeleportToTransform(Transform target)
    {
        if (!target) return;

        bool hadCC = _cc != null;
        if (hadCC) _cc.enabled = false;

        transform.SetPositionAndRotation(target.position, target.rotation);

        if (hadCC) _cc.enabled = true;
    }

    public void TeleportToScene(string sceneName, string spawnPointName = null)
    {
        PendingSpawnPointName = string.IsNullOrWhiteSpace(spawnPointName) ? null : spawnPointName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (string.IsNullOrWhiteSpace(PendingSpawnPointName)) return;

        var spawn = GameObject.Find(PendingSpawnPointName);
        if (spawn != null)
        {
            bool hadCC = _cc != null;
            if (hadCC) _cc.enabled = false;

            transform.SetPositionAndRotation(spawn.transform.position, spawn.transform.rotation);

            if (hadCC) _cc.enabled = true;
        }

        PendingSpawnPointName = null;
    }
}
