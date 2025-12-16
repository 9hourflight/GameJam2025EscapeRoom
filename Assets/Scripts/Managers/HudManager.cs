using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;

    [SerializeField] private TMP_Text interactText;
    [SerializeField] private GameObject interactObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void EnableInteractionText(string _text)
    {
        interactText.text = _text + " (E)";
        interactText.gameObject.SetActive(true);
        interactObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
            interactObject.SetActive(false);
        }
    }
}
