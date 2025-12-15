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
    public static readonly int numRows = 3;
    public static readonly int numCols = 3;

    [SerializeField] private Transform keySpawnLocation;
    [SerializeField] private LightsOutManager[,] tiles = new LightsOutManager[numRows, numCols];

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
