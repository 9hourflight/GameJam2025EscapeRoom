using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsPuzzleOver;
    public bool IsKeyPickedUp;
    public GameObject KeyToDoor;
    public int randomPuzzle;

    [SerializeField] private Transform keySpawnLocation;

    [Header("Game Setup for Puzzles")]
    [SerializeField] private Transform puzzleLocation;
    [SerializeField] private GameObject puzzle01;
    [SerializeField] private GameObject puzzle02;

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

    private void Start()
    {
        int randomPuzzle = FrontEnd.Instance.randomPuzzle;

        if (puzzleLocation != null)
        {
            if (randomPuzzle == 1)
            {
                puzzle01 = Instantiate(puzzle01, puzzleLocation, puzzleLocation);
            }
            else
            {
                puzzle02 = Instantiate(puzzle02, puzzleLocation);
            }
        }
    }

    public void PuzzleCompleted()
    {
        KeyToDoor = Instantiate(KeyToDoor, keySpawnLocation);
        IsPuzzleOver = true;
        PlayerInteractivity.IsInteracting = false;
        TimerManager.Instance.isTimerStart = false;
        Debug.Log("You completed the puzzle!!");
    }
}
