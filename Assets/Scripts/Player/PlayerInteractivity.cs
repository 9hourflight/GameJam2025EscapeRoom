using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class PlayerInteractivity : MonoBehaviour
{
    public GameObject InteractText;
    public GameObject ExitPuzzleText;
    public static bool IsInteracting;
    public float playerReach = 3f; //The distance of which the player can interact with an object

    [SerializeField] GameObject puzzleCamera;
    [SerializeField] GameObject player;

    private Interactable currentInteractable;

    private void Awake()
    {
        InteractText.SetActive(false);
        ExitPuzzleText.SetActive(false);
        puzzleCamera.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {

        }


        /*if(IsInteracting && Input.GetKeyDown(KeyCode.E))
        {
            ExitPuzzleText.SetActive(true);
            puzzleCamera.SetActive(true);
            player.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPuzzleText.SetActive(false);
            puzzleCamera.SetActive(false);
            player.SetActive(true);
        }*/
    }

    private void InteractWithPuzzle()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IsInteracting = true;
        InteractText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        IsInteracting = false;
        InteractText.SetActive(false);
    }
}
