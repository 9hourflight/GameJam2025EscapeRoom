using System.Collections;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject puzzleInstructionsLeft, puzzleInstructionsRight;
    [SerializeField] private GameObject actualPuzzleInstructions;
    [SerializeField] private GameObject beginPuzzleButton;
    [SerializeField] private GameObject loadingBar;
    [SerializeField] private string LoadInGame;

    void Start()
    {
        StartCoroutine(ShowInstructions());
    }

    IEnumerator ShowInstructions()
    {
        yield return new WaitForSeconds(10f);
        puzzleInstructionsLeft.SetActive(false);
        puzzleInstructionsRight.SetActive(false);

        actualPuzzleInstructions.SetActive(true);

        yield return new WaitForSeconds(20f);
        loadingBar.SetActive(false);
        beginPuzzleButton.SetActive(true);
    }

    public void OnBeginClicked()
    {
        SceneManager.LoadScene(LoadInGame);
    }
}
