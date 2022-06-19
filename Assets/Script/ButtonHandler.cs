using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public InputField numRow;
    public InputField numCol;
    public InputField numMine;

    public void BeginClicked()
    {
        
        GameManager.Instance.numRow = int.Parse(numRow.text);
        GameManager.Instance.numCol = int.Parse(numCol.text);
        GameManager.Instance.numMine = int.Parse(numMine.text);

        SceneManager.LoadScene("GameScene");
    }

    public void BeginnerClicked()
    {
        GameManager.Instance.numRow = 9;
        GameManager.Instance.numCol = 9;
        GameManager.Instance.numMine = 10;

        SceneManager.LoadScene("GameScene");
    }

    public void IntermediateClicked()
    {
        GameManager.Instance.numRow = 15;
        GameManager.Instance.numCol = 13;
        GameManager.Instance.numMine = 40;

        SceneManager.LoadScene("GameScene");
    }

    public void ExpertClicked()
    {
        GameManager.Instance.numRow = 30;
        GameManager.Instance.numCol = 16;
        GameManager.Instance.numMine = 99;

        SceneManager.LoadScene("GameScene");
    }
}
