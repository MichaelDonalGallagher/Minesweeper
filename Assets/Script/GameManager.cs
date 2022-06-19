using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance { get { return instance;} }

    public int numRow = 6;
    public int numCol = 4;
    public int numMine = 2;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }
}
