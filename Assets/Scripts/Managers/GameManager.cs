using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject keyToDoor;
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
        Instantiate(keyToDoor, keySpawnLocation);
        Debug.Log("You completed the puzzle!!");
    }
}
