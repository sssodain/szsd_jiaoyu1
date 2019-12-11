using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ARRoot;
    public GameObject GameRoot;

    public Transform ARCam;
    public Transform GameCam;

    public UnityEngine.UI.Image ScanLine;
    private void Awake()
    {
        Instance = this;
        ARCam.GetComponent<VuforiaBehaviour>().enabled = false;
    }

    private void Start()
    {
        SwitchGame(0);
        ARCam.GetComponent<VuforiaBehaviour>().enabled = true;
    }


    public void SwitchGame(int type )
    {
        if (type == 0)
        {
            ScanLine.gameObject.SetActive(true);
            ARRoot.SetActive(true);
            GameRoot.SetActive(false);
            ARCam.position = Vector3.zero;
            ARCam.eulerAngles = Vector3.zero;
        }
        else if (type == 1)
        {
        
            AudioManager.Instance.PlayAudio("Background", SoundType.Bac,false, 0.5f);
            ScanLine.gameObject.SetActive(false);
            ARRoot.SetActive(false);
            GameRoot.SetActive(true);
            ARCam.position = new Vector3(-2.69f,6.88f,0.93f);
            ARCam.eulerAngles = GameCam.eulerAngles;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }









}
