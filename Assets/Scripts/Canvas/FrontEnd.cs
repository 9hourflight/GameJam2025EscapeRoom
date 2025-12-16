using UnityEngine;

public class FrontEnd : MonoBehaviour
{

    [Header("Ensure that puzzle-Number is the same as InGame Scene")]
    [SerializeField] bool isPuzzleRigged;
    [SerializeField] int riggedPuzzle;

    private void Start()
    {
        int randomPuzzle = Random.Range(1, 2);

        if (isPuzzleRigged)
        {
            randomPuzzle = riggedPuzzle;
        }

        if (randomPuzzle == 1)
        {
            Instantiate(Resources.Load("Canvas/" + "LoadPuzzle1_Canvas") as GameObject);
        }
        else
        {
            Instantiate(Resources.Load("Canvas/" + "LoadPuzzle2_Canvas") as GameObject);
        }
    }
}
