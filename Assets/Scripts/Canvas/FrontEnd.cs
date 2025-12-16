using System.Collections;
using UnityEngine;

public class FrontEnd : MonoBehaviour
{
    public static FrontEnd Instance;
    public int randomPuzzle;

    [Header("Ensure that puzzle-Number is the same as InGame Scene")]
    [SerializeField] bool isPuzzleRigged;
    [SerializeField] int riggedPuzzle;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        randomPuzzle = Random.Range(1, 3);

        if (isPuzzleRigged)
        {
            randomPuzzle = riggedPuzzle;
        }
    }

    
    public void OnStartPressed()
    {
        if (randomPuzzle == 1)
        {
            Instantiate(Resources.Load("Canvas/" + "LoadPuzzle1_Canvas") as GameObject);
        }
        else
        {
            Instantiate(Resources.Load("Canvas/" + "LoadPuzzle2_Canvas") as GameObject);
        }
        Destroy(gameObject);
    }
}
