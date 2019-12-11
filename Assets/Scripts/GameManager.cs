using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ARRoot;
    public GameObject GameRoot;

    public Transform ARCam;
    public Transform GameCam;

    public Image ScanLine;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SwitchGame(0);
    }


    public void SwitchGame(int type )
    {
        if (type == 0)
        {
            ScanLine.gameObject.SetActive(true);
            ARRoot.SetActive(true);
            GameRoot.SetActive(false);
        }
        else if (type == 1)
        {
            ScanLine.gameObject.SetActive(false);
            ARRoot.SetActive(false);
            GameRoot.SetActive(true);
            ARCam.position = new Vector3(-2.69f,6.88f,0.93f);
            ARCam.eulerAngles = GameCam.eulerAngles;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }









}
