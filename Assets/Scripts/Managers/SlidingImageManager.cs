using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class SlidingImageManager : MonoBehaviour
{
    public event Action OnCompletingPuzzle;

    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private List<Transform> pieces;
    private int emptyLocation;
    private int size;

    private void Start()
    {
        pieces = new List<Transform>();
        size = 3;
        CreateGamePieces(0.01f);
        StartCoroutine(WaitToShuffle(0.5f));
        OnCompletingPuzzle += GameManager.Instance.PuzzleCompleted;
    }

    private void Update()
    {
        if (PlayerInteractivity.IsInteracting && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i] == hit.transform)
                    {
                        // Check each direction to see if it is a valid move
                        // Break out on success so we don't carry on and swap back again
                        if (SwapIfValid(i, -size, size))
                        {
                            break;
                        }
                        if (SwapIfValid(i, +size, size))
                        {
                            break;
                        }
                        if (SwapIfValid(i, -1, 0))
                        {
                            break;
                        }
                        if (SwapIfValid(i, +1, size - 1))
                        {
                            break;
                        }
                    }
                }
            }
            CheckCompletion();
        }
    }

    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        OnCompletingPuzzle?.Invoke();
        PlayerInteractivity.IsInteracting = false;
        return true;
    }

    /// <summary>
    /// This handles swaping an image piece by checking if the image is directly next to the image that is not there(is false)
    /// </summary>
    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % size) != colCheck) && ((i + offset) == emptyLocation))
        {
            (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
            (pieces[i].localPosition, pieces[i + offset].localPosition) = (pieces[i + offset].localPosition, pieces[i].localPosition);
            emptyLocation = i;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Set the puzzle pieces on to a parent and then create the image based on size.
    /// </summary>
    private void CreateGamePieces(float gapThickness)
    {
        float width = 1 / (float)size;
        for(int row = 0; row < size; row++)
        {
            for(int col = 0; col < size; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);
                piece.localPosition = new Vector3(-1 + (2 * width * col) + width, +1 - (2 * width * row) - width, 0);
                piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.name = $"{(row * size) + col}";
                if ((row == size - 1) && (col == size - 1))
                {
                    emptyLocation = (size * size) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    float gap = gapThickness / 2;
                    Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                    Vector2[] uv = new Vector2[4];
                    uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
                    uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
                    uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
                    uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
                    mesh.uv = uv;
                }
            }
        }
    }

    private IEnumerator WaitToShuffle(float _duration)
    {
        yield return new WaitForSeconds(_duration);
        Shuffle();
    }

    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while(count < (size * size * size))
        {
            int random = UnityEngine.Random.Range(0, size * size);
            if (random == last)
            {
                continue;
            }
            last = emptyLocation;
            if (SwapIfValid(random, -size, size))
            {
                count++;
            }
            else if (SwapIfValid(random, +size, size))
            {
                count++;
            }
            else if (SwapIfValid(random, -1, 0))
            {
                count++;
            }
            else if (SwapIfValid(random, +1, size - 1))
            {
                count++;
            }
        }
    }
}
