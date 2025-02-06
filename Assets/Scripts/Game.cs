using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject selecter;
    [SerializeField] private GameObject Yellow;
    [SerializeField] private GameObject Red;
    [SerializeField] private GameObject text;
    private int[][] grid;
    public int player = 1;
    private bool turn = false;
    private bool win = false;
    private int turnCount = 0;

    private void Start()
    {
        CreateGrid();
    }

    private void Update()
    {
        if (win)
        {
            text.SetActive(true);
            return;
        }
        while (!turn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                turn = Play((int)selecter.transform.position.x);
            }
            return;
        }
        turnCount += 1;
        turn = false;
        if (player == 1)
        {
            player = 2;
        }
        else
        {
            player = 1;
        }
    }

    void CreateGrid()
    {
        grid = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            grid[i] = new int[7];
        }
    }

    bool Play(int col)
    {
        for (int i = 5; i > -1; i--)
        {
            if (grid[i][col] == 0)
            {
                grid[i][col] = player;
                if (player == 1)
                {
                    Instantiate(Yellow, new Vector3(col, 5-i, 0), Quaternion.Euler(90,0,0));
                }
                else
                {
                    Instantiate(Red, new Vector3(col, 5-i, 0), Quaternion.Euler(90,0,0));
                }
                win = isWinning(i, col);
                return true;
            }
        }
        return false;
    }

    bool isWinning(int y, int x)
    {
        int c = 0;
        for (int i = y; i < Mathf.Min(y+3, 5)+1 ; i++)
        {
            if (grid[i][x] == player)
            {
                c += 1;
                if (c == 4)
                {
                    Debug.Log(player + "a gagné");
                    return true;
                }
            }
        }
        c = 0;
        for (int i = 0; i < 7; i++)
        {
            if (grid[y][i] == player)
            {
                c += 1;
                if (c == 4)
                {
                    Debug.Log(player + "a gagné");
                    return true;
                }
            }
            else
            {
                c = 0;
            }
        }
        c = 0;
        return false;
    }

    public void restart()
    {
        text.SetActive(false);
        win = false;
        CreateGrid();
        GameObject[] tokens = GameObject.FindGameObjectsWithTag("token");
        foreach(GameObject token in tokens)
            Destroy(token);
        turn = false;
        player = 1;
    }
    
}
