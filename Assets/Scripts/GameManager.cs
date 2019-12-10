using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ARRoot;
    public GameObject GameRoot;
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
        }
    }


}
