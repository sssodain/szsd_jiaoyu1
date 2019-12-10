using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinFuManager : MonoBehaviour
{
    public static YinFuManager Instance;

    public Transform prefabTras;
    public List<GameObject> yinfuprefablist = new List<GameObject>();
    public Transform generateroot;

    public List<yinfuitem> CurYinFuList = new List<yinfuitem>();

    public Transform startpoint;
    public List<Transform> startList = new List<Transform>();
    public Transform flypoint;
    public List<Transform> flyList = new List<Transform>();
    private void Awake()
    {
        Instance = this;
        prefabTras.gameObject.SetActive(false);

        CurYinFuList.Clear();
        yinfuprefablist.Clear();
        for (int i = 0; i < prefabTras.childCount; i++)
        {
            yinfuprefablist.Add(prefabTras.GetChild(i).gameObject);
        }

        for (int i = 0; i < startpoint.childCount; i++)
        {
            startList.Add(startpoint.GetChild(i));
        }

        for (int i = 0; i < flypoint.childCount; i++)
        {
            flyList.Add(flypoint.GetChild(i));
        }
    }


    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Generate_yinfu();
        }
    }

    private GameObject GetPrefab()
    {
        int index = Random.Range(0, yinfuprefablist.Count);
        return yinfuprefablist[index];
    }

    private Vector3 GetGeneratePosition()
    {
        int tmpIndex = Random.Range(0, startList.Count);
        return startList[tmpIndex].localPosition;
    }

    int yinfuId = 0;
    public void Generate_yinfu()
    {
        GameObject prefab = GetPrefab();
        GameObject newgo = GameObject.Instantiate(prefab);
        newgo.transform.SetParent(generateroot);
        newgo.transform.localPosition = GetGeneratePosition();
        newgo.transform.localScale = Vector3.one;
        newgo.SetActive(true);
        yinfuitem yinfuitem = newgo.GetComponent<yinfuitem>();
        yinfuitem.yinfuId = yinfuId;
        yinfuId++;
        CurYinFuList.Add(yinfuitem);
    }


}