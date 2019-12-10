using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    public Text text;
    private void Awake()
    {
        Instance = this;
    }

    int curCount = 0;
    public void Add()
    {
        curCount++;
        if (curCount >= 5)
        {
            curCount = 0;
            ProcessManager.Instance.Start_paodai();
        }
        text.text = "" + curCount + "/" + 5;

    }


}
