using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book : MonoBehaviour
{
    void playtx()
    {
        //Debug.LogError("播放传送带特效playtx");
        ProcessManager.Instance.PlayChuanSongTX();
    }
}
