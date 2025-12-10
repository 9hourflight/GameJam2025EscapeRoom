using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsPuzzleOver;
    public bool IsKeyPickedUp;
    public GameObject KeyToDoor;

    [SerializeField] private Transform keySpawnLocation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PuzzleCompleted()
    {
        KeyToDoor = Instantiate(KeyToDoor, keySpawnLocation, keySpawnLocation);
        IsPuzzleOver = true;
        PlayerInteractivity.IsInteracting = false;
        TimerManager.Instance.isTimerStart = false;
        Debug.Log("You completed the puzzle!!");
    }
}
