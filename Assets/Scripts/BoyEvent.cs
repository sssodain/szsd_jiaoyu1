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
        AudioManager.Instance.PlayAudio("desolate", SoundType.Bac, true, 1);
        AudioManager.Instance.StopAudio("Background");
        ProcessManager.Instance.Play_yinfu_effect();
        if (count == 1)
        {
            YinFuManager.Instance.CheckGenerate();
            TipUI.Instance.SetActive(true);
            GameUI.Instance.show();
            count++;
        }
    }


    private void OnEnable()
    {
        count = 1;
    }
}
