using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameStarted;
    //public static int Score;
    public static int Municiones;
    public static int HP = 3;
    public static bool isGamePaused;
    public static bool Shooting;

    public static bool levelUp;

    public static int BossHP = 8;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
