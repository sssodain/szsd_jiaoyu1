using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

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

    public GameObject piaodai_prefab;
    public GameObject piaodai;
    public Transform boyroot;
    public Transform boytodai;
    public Image fadeImag;
    private void Awake()
    {
        Instance = this;
        BookAnimator = book.GetComponent<Animator>();
        boyAnimator = boy.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ChuanSongTXRoot.gameObject.SetActive(false);
        boy.gameObject.SetActive(false);
        xuanwo.gameObject.SetActive(false);
        yinfu_effect.gameObject.SetActive(false);
        boy.gameObject.SetActive(false);

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
        GameObject newgo = GameObject.Instantiate(piaodai_prefab);
        newgo.transform.SetParent(transform);
        newgo.transform.localEulerAngles = Vector3.zero;
        newgo.transform.localPosition = Vector3.zero;
        newgo.transform.localScale = Vector3.one;
        piaodai = newgo;
        
    }

    public void BoyToPaoDai()
    {
        paodaiEvent paodaiEvent = piaodai.GetComponentInChildren<paodaiEvent>();
        boyroot.SetParent(paodaiEvent.BoyParent);
    }

    public void ResetGame()
    {
        //黑屏逻辑
        fadeImag.gameObject.SetActive(true);
        fadeImag.DOColor(new Color(0,0,0,1), 1.5f);

        //重新加载场景
        MyStartCoroutine(2f, delegate ()
        {
            GameManager.Instance.SwitchGame(0);
            fadeImag.gameObject.SetActive(false);
            fadeImag.DOColor(new Color(0, 0, 0, 0), 0f);



            boyroot.SetParent(transform);
            boyroot.transform.localPosition = Vector3.zero;
            boyroot.transform.localEulerAngles = Vector3.zero;
            boyroot.transform.localScale = Vector3.one;
            GameObject.Destroy(piaodai);
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