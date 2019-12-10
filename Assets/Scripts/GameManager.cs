using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ARRoot;
    public GameObject GameRoot;

    public Transform ARCam;
    public Transform GameCam;
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
            ARRoot.SetActive(true);
            GameRoot.SetActive(false);
        }
        else if (type == 1)
        {
            ARRoot.SetActive(false);
            GameRoot.SetActive(true);
            ARCam.position = new Vector3(-2.69f,6.88f,0.93f);
            ARCam.eulerAngles = GameCam.eulerAngles;
        }
    }





}
