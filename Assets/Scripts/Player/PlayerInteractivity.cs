using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractivity : MonoBehaviour
{
    [SerializeField] private bool isInteractable = false;
    public GameObject interactButton;

    private void Awake()
    {
        interactButton.SetActive(false);
    }

    private void Update()
    {
        if (isInteractable && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E has been pressed.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInteractable = true;
        interactButton.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        isInteractable = false;
        interactButton.SetActive(false);
    }
}
