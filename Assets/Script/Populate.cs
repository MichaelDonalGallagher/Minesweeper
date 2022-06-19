using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Populate : MonoBehaviour
{
    public GameObject prefab;
    [HideInInspector] public static GameObject[,] mineField;
    [HideInInspector] public static int numRows;
    [HideInInspector] public static int numCols;
    public static int numMines;
    [HideInInspector] public static int totalGridElements = 0;
    [HideInInspector] public static int totalUncoveredElements = 0;

    void Start()
    {
        numRows = GameManager.Instance.numRow;
        numCols = GameManager.Instance.numCol;
        numMines = GameManager.Instance.numMine;

        mineField = new GameObject[numRows, numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                mineField[row,col] = Instantiate(prefab, new Vector2(col - (numCols/2), row - (numRows/2)), Quaternion.identity);
                /*if ((col % 2) == 0)
                    mineField[row, col].GetComponent<GridElement>().setIsMine();*/
                mineField[row, col].GetComponent<GridElement>().setYCoord(row - (numRows / 2));
                mineField[row, col].GetComponent<GridElement>().setXCoord(col - (numCols / 2));
                totalGridElements++;
            }
        }

        for (int i = 0; i < numMines; i++)
        {
            int x = (Random.Range(0, numRows));
            int y = (Random.Range(0, numCols));
            if (mineField[x, y].GetComponent<GridElement>().getIsMine() == false)
                mineField[x, y].GetComponent<GridElement>().setIsMine();
        }
    }
    static public int getNumSurroundingMines(int x, int y)
    {
        int total = 0;

        if (isCellMine(x - 1, y + 1))
            total++;
        if (isCellMine(x, y + 1))
            total++;
        if (isCellMine(x + 1, y + 1))
            total++;
        if (isCellMine(x - 1, y))
            total++;
        if (isCellMine(x + 1, y))
            total++;
        if (isCellMine(x - 1, y - 1))
            total++;
        if (isCellMine(x, y - 1))
            total++;
        if (isCellMine(x + 1, y - 1))
            total++;

        return total;
    }

    static public bool isCellMine(int x, int y)
    {     
        //print("(" + x + "," + y + ")");
        if (x < 0 - (numCols / 2)  || x > (numCols / 2))
        {
            return false;
        }
        else if (y < 0 - (numRows / 2) || y > (numRows / 2))
        {
            return false;
        }        
        if (mineField[y + (numRows / 2), x + (numCols / 2)].GetComponent<GridElement>().getIsMine())
        {      
            return true;
        }            
        return false;
    }   

    public static void setTotalUncovered()
    {
        totalUncoveredElements++;
    }

    public static void showAllMines()
    {
        for (int i = 0; i < Populate.numRows; i++)
        {
            for (int j = 0; j < Populate.numCols; j++)
            {
                GridElement cell = Populate.mineField[i, j].GetComponent<GridElement>();
                if (cell.isMine)
                {
                    cell.GetComponent<SpriteRenderer>().sprite = cell.GetComponent<InputHandler>().images[10];
                }
            }
        }
    }

    public static void handleCell(int x, int y)
    {
        if (x < 0 - (numCols / 2) || x > (numCols / 2))
        { }
        else if (y < 0 - (numRows / 2) || y > (numRows / 2))
        { }
        else
        {
            GridElement cell = mineField[y + (numRows / 2), x + (numCols / 2)].GetComponent<GridElement>();
            if (cell.getHasBeenVisited() != true)
            {

                if (cell.getIsMine())
                {
                    cell.GetComponent<SpriteRenderer>().sprite = cell.GetComponent<InputHandler>().images[10];
                    print("You Lose!");
                    Populate.showAllMines();
                }
                else if (Populate.getNumSurroundingMines(x, y) > 0)
                {
                    if (cell.GetComponent<SpriteRenderer>().sprite != cell.GetComponent<InputHandler>().images[Populate.getNumSurroundingMines(x, y)])
                    {
                        cell.GetComponent<SpriteRenderer>().sprite = cell.GetComponent<InputHandler>().images[Populate.getNumSurroundingMines(x, y)];
                        cell.setCellUncovered();
                    }
                }
                else
                {
                    if (cell.GetComponent<SpriteRenderer>().sprite != cell.GetComponent<InputHandler>().images[0])
                    {
                        cell.GetComponent<SpriteRenderer>().sprite = cell.GetComponent<InputHandler>().images[0];
                        cell.setCellUncovered();
                        handleCell(x + 1, y + 1);
                        handleCell(x + 1, y);
                        handleCell(x + 1, y - 1);
                        handleCell(x, y + 1);
                        handleCell(x, y - 1);
                        handleCell(x - 1, y + 1);
                        handleCell(x - 1, y);
                        handleCell(x - 1, y - 1);
                    }
                }
                if (Populate.totalGridElements - Populate.totalUncoveredElements == Populate.numMines)
                    print("You Win!");
                cell.setHasBeenVisited();
            }
        }
    }
}
