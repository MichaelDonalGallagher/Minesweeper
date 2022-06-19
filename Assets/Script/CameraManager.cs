using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        if(GameManager.Instance.numRow >= GameManager.Instance.numCol)
        {
            Camera.main.orthographicSize = (float)GameManager.Instance.numRow / 2;
            if((float)GameManager.Instance.numRow % 2 ==0)
                mainCamera.transform.position = new Vector3(0, 0, -10);
            else
                mainCamera.transform.position = new Vector3(0.5f, 0.5f, -10);
        }
        else
        {
            Camera.main.orthographicSize = (float)GameManager.Instance.numCol / 2;
            if ((float)GameManager.Instance.numCol % 2 == 0)
                mainCamera.transform.position = new Vector3(0, 0, -10);
            else
                mainCamera.transform.position = new Vector3(0.5f, 0.5f, -10);
        }
        
    }
}
