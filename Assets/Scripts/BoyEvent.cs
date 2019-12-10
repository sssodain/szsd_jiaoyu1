using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyEvent : MonoBehaviour
{
    int count = 1;
    void ChuiLoop()
    {
        //Debug.LogError("boy播放吹笛子动画");
        ProcessManager.Instance.SwitchBoyAnim("ChuiLoop");
        ProcessManager.Instance.Play_yinfu_effect();
        if (count == 1)
        {
            YinFuManager.Instance.CheckGenerate();
            count++;
        }
    }
}
