using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSystem : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    Draggable[] draggables;
    public GameManager gameManager;
    void Start()
    {
        if(gameManager != null)
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        WithForeachLoop();

        StartCoroutine(LateStart(1));

        IEnumerator LateStart(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            draggables = FindObjectsOfType<Draggable>();
            if (draggables.Length == 0)
            {
                if (tiles[0].taken && tiles[1].taken && tiles[2].taken)
                {
                    gameManager.WinGame();
                }
                else if (tiles[3].taken && tiles[4].taken && tiles[5].taken)
                {
                    gameManager.WinGame();
                }
                else if (tiles[6].taken && tiles[7].taken && tiles[8].taken)
                {
                    gameManager.WinGame();
                }
                else
                {
                    gameManager.LoseGame();
                }
            }
        }
    }

    void WithForeachLoop()
    {
        var i = 0;
        foreach (Transform child in transform)
        {
            i++;
            child.GetComponent<Tile>().SetId(i);
            tiles.Add(child.GetComponent<Tile>());
        }
    }

    public void CheckValues()
    {
        draggables = FindObjectsOfType<Draggable>();
        if (draggables.Length == 1)
        {
            if (tiles[0].taken && tiles[1].taken && tiles[2].taken)
            {
                gameManager.WinGame();
            }
            else if (tiles[3].taken && tiles[4].taken && tiles[5].taken)
            {
                gameManager.WinGame();
            }
            else if (tiles[6].taken && tiles[7].taken && tiles[8].taken)
            {
                gameManager.WinGame();
            }
            else
            {
                gameManager.LoseGame();
            }
        }
    }
}
