using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paodaiEvent : MonoBehaviour {

    public Transform BoyParent;
    void NewEvent()
    {
        ProcessManager.Instance.BoyToPaoDai();
    }


    void ResetGame()
    {
        ProcessManager.Instance.ResetGame();
    }
}
