using System.Collections;
using UnityEngine;

public class LoadPuzzle1 : MonoBehaviour
{
    [SerializeField] private GameObject puzzleInstructionsLeft, puzzleInstructionsRight;
    [SerializeField] private GameObject actualPuzzleInstructions;

    private float waitToShow = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator ShowInstructions(float timer)
    {
        yield return new WaitForSeconds(timer);
    }
}
