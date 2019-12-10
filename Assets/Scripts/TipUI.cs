using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipUI : MonoBehaviour
{
    public static TipUI Instance;
    private void Awake()
    {
        Instance = this;
        SetActive(false);
    }


    public void SetActive(bool isShow)
    {
        gameObject.SetActive(isShow);
    }


}
