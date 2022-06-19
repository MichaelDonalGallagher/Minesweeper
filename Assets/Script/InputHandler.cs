using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Sprite[] images;

    GridElement gridElement;
    private void Start()
    {
        gridElement = this.GetComponent<GridElement>();
    }
    
    void OnMouseUp()
    {
        Populate.handleCell(gridElement.getXCoord(), gridElement.getYCoord());
        /*if (gridElement.getIsMine())
        {
            this.GetComponent<SpriteRenderer>().sprite = images[10];
            print("You Lose!");
            Populate.showAllMines();
        }
        else if (Populate.getNumSurroundingMines(gridElement.getXCoord(), gridElement.getYCoord()) > 0)
        {
            if (this.GetComponent<SpriteRenderer>().sprite != images[Populate.getNumSurroundingMines(gridElement.getXCoord(), gridElement.getYCoord())])
            {
                this.GetComponent<SpriteRenderer>().sprite = images[Populate.getNumSurroundingMines(gridElement.getXCoord(), gridElement.getYCoord())];
                gridElement.setCellUncovered();
            }
        }
        else
        {
            if (this.GetComponent<SpriteRenderer>().sprite != images[0])
            {
                this.GetComponent<SpriteRenderer>().sprite = images[0];
                //handleCell(gridElement.getXCoord(), gridElement.getYCoord());
                gridElement.setCellUncovered();
            }
        }
        if (Populate.totalGridElements - Populate.totalUncoveredElements == Populate.numMines)
            print("You Win!");
        gridElement.setHasBeenVisited();*/
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && gridElement.getHasBeenVisited() == false)
            if (this.GetComponent<SpriteRenderer>().sprite == images[9])
                this.GetComponent<SpriteRenderer>().sprite = images[11];
            else
                this.GetComponent<SpriteRenderer>().sprite = images[9];
    }
}
