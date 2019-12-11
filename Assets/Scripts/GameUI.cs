using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    [SerializeField] private GameObject _molecule;
    private List<Image> _moleculeImgList = new List<Image>();
    private void Awake()
    {
        Instance = this;
        //text.gameObject.SetActive(false);
        initMolecule();
    }
    private void initMolecule()
    {
        for (int i = 0; i < _molecule.transform.childCount; i++)
        {
            _moleculeImgList.Add(_molecule.transform.GetChild(i).GetComponent<Image>());
            if (i!=0)
            {
                _moleculeImgList[i].gameObject.SetActive(false);
            }
        }
    }
    public void show()
    {
        //  text.gameObject.SetActive(true);
        _molecule.SetActive(true);
    }

    private void OnEnable()
    {
        curCount = 0;
    }

    int curCount = 0;
    public void Add()
    {
        curCount++;
        if (curCount >= 5)
        {
            //curCount = 0;
            ProcessManager.Instance.Start_paodai();
        }
        for (int i = 0; i < _moleculeImgList.Count; i++)
        {
            if (i == curCount)
            {
                _moleculeImgList[i].gameObject.SetActive(true);
            }
            else
            {
                _moleculeImgList[i].gameObject.SetActive(false);
            }
        }
    }

}
