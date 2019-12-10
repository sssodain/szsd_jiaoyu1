using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yinfuitem : MonoBehaviour
{
    public int yinfuId = 0;
    private float RotationSpeed = 10f;

    private void Awake()
    {
        RotationSpeed = Random.Range(15, 30);
        if (Random.Range(0, 100) > 50) RotationSpeed *= -1;
    }


    void Start()
    {
        StartFly();
    }

    void Update()
    {
        Vector3 V3_Ro = transform.localEulerAngles;
        V3_Ro.z += Time.deltaTime * RotationSpeed;
        transform.localEulerAngles = V3_Ro;
    }

    int flyIndex = -1;
    private Vector3 GetFlyPosition()
    {
        List<Transform> list = YinFuManager.Instance.flyList;
        int tmp = -10;
        for (int i = 0; i < 5; i++)
        {
            tmp = Random.Range(0, list.Count);
            if (tmp != flyIndex)
            {
                flyIndex = tmp;
                break;
            }
        }

        //List<Transform> list = YinFuManager.Instance.flyList;
        //int tmpIndex = Random.Range(0, list.Count);
        return list[flyIndex].localPosition;
    }


    private void SetNext()
    {


    }


    public void StartFly()
    {
        Vector3 vector3 = GetFlyPosition();
        //Debug.LogError("vector3="+ vector3);
        float time = Random.Range(8f, 15);
        transform.DOLocalMove(vector3, time).OnComplete(delegate() 
        {
            StartFly();
        });
    }


    public void OnClick()
    {
        Debug.LogError("OnClick");
        transform.DOKill();
        Transform boyTrans = ProcessManager.Instance.boy.transform;
        Vector3 vector3 = Camera.main.WorldToViewportPoint(boyTrans.position);
        Debug.LogError("vector3=" + vector3);

        transform.DOLocalMove(vector3, 10f).OnComplete(delegate ()
        {

        });
    }
}
