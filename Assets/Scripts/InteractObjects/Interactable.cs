using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message;
    public UnityEvent onInteraction;

    [SerializeField] private GameObject doorPivot;

    private Animator doorOpening;

    private void Start()
    {
        outline = GetComponent<Outline>();
        if(doorPivot != null)
        {
            doorOpening = GetComponentInParent<Animator>();
        }
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void OnKeyPickedUp()
    {
        GameManager.Instance.IsKeyPickedUp = true;
        Destroy(GameManager.Instance.KeyToDoor);
    }

    public void OnDoorClicked()
    {
        if(GameManager.Instance.IsKeyPickedUp)
        {
            doorOpening.SetTrigger("OpenDoor");
        }
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        outline.enabled = true;
    }
}
