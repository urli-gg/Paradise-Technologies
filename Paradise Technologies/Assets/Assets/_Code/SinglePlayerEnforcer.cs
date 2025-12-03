using UnityEngine;

public class SinglePlayerEnforcer : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyPlayers", 0.1f);
    }

    private void DestroyPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            for (int i = 1; i < players.Length; i++)
            {
                Destroy(players[i]);
            }

            Debug.Log("Destroyed extra players");
        }
    }
}
