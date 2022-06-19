using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : MonoBehaviour
{
    public bool isMine = false;
    bool hasBeenVisited = false;
    private bool cellUncovered = false;
    private int xCoord;
    private int yCoord;

    public bool getIsMine()
    {
        //print("(" + xCoord + "," + yCoord + ")");
        return isMine;
    }

    public int getXCoord()
    {
        return xCoord;
    }

    public void setXCoord(int xCoord)
    {
        this.xCoord = xCoord;
    }

    public int getYCoord()
    {
        return yCoord;
    }

    public void setYCoord(int yCoord)
    {
        this.yCoord = yCoord;
    }

    public void setIsMine()
    {
        this.isMine = true;
    }

    public bool getHasBeenVisited()
    {
        return hasBeenVisited;
    }

    public void setHasBeenVisited()
    {
        this.hasBeenVisited = true;
    }    

    public void setCellUncovered()
    {
        this.cellUncovered = true;
        Populate.setTotalUncovered();
    }
}
