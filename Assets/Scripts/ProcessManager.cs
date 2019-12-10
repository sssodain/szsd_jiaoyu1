using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ProcessManager : MonoBehaviour
{
    public static ProcessManager Instance;
    public Transform book;
    private Animator BookAnimator;
    public Transform ChuanSongTXRoot;
    public Transform boy;
    private Animator boyAnimator;


    public Transform xuanwo;
    public Transform yinfu_effect;

    public Transform piaodai;
    private Animator piaodaiAnimator;
    public Transform boyroot;
    public Transform boytodai;
    private void Awake()
    {
        Instance = this;

        boy.gameObject.SetActive(false);

        BookAnimator = book.GetComponent<Animator>();
        boyAnimator = boy.GetComponent<Animator>();
        piaodaiAnimator = piaodai.GetComponent<Animator>();
    }

    private void Start()
    {
        SwitchBookAnim("play");
    }

    public void MyStartCoroutine(float time, System.Action action)
    {
        StartCoroutine(DelayAction(time, action));
    }

    private IEnumerator DelayAction(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        if (action != null) action();
    }

    //1.翻书
    public void SwitchBookAnim(string TriggerName)
    {
        BookAnimator.SetTrigger(TriggerName);
    }

    //2.传送特效
    public void PlayChuanSongTX()
    {
        ChuanSongTXRoot.gameObject.SetActive(true);
        Play_xuanwo();
        MyStartCoroutine(1f,delegate() 
        {
            ShowBoy();
        });
    }

    //3.boy出现
    public void ShowBoy()
    {
        //Debug.LogError("boy出现");
        boy.gameObject.SetActive(true);
        SwitchBoyAnim("ComeOut");
    }

    public void SwitchBoyAnim(string TriggerName)
    {
        boyAnimator.SetTrigger(TriggerName);
    }


    public void Play_xuanwo()
    {
        xuanwo.gameObject.SetActive(true);
        ParticleSystem[] effects = xuanwo.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }

    public void Play_yinfu_effect()
    {
        yinfu_effect.gameObject.SetActive(true);
        ParticleSystem[] effects = yinfu_effect.GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }

    public void Start_paodai()
    {
        piaodai.gameObject.SetActive(true);
    }

    public void BoyToPaoDai()
    {
        boyroot.SetParent(boytodai);
    }

    public void ResetGame()
    {
        //黑屏逻辑


        //重新加载场景
        MyStartCoroutine(2f, delegate ()
        {
            SceneManager.LoadScene("Main");
        });
    }


    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha0)) SwitchBoyAnim("K0");
    //    if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchBoyAnim("1");
    //    if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchBoyAnim("2");
    //    if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchBoyAnim("3");
    //    if (Input.GetKeyDown(KeyCode.Alpha4)) SwitchBoyAnim("4");
    //    if (Input.GetKeyDown(KeyCode.Alpha5)) SwitchBoyAnim("5");
    //}
}