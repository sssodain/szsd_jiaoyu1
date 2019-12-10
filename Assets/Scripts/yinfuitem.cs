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
        return list[flyIndex].localPosition;
    }

    public void StartFly()
    {
        Vector3 vector3 = GetFlyPosition();
        float time = Random.Range(8f, 15);
        transform.DOLocalMove(vector3, time).OnComplete(delegate() 
        {
            StartFly();
        });
    }


    bool IsCanClick = true;
    public void OnClick()
    {
        if (!IsCanClick) return;
        IsCanClick = false;
        TipUI.Instance.SetActive(false);
        transform.DOKill();
        //Transform boyTrans = ProcessManager.Instance.boy.transform;
        //Vector3 vector3 = Camera.main.WorldToViewportPoint(boyTrans.position);
        //Debug.LogError("OnClick");
        //Debug.LogError("vector3=" + vector3);
        //飘过去
        Vector3 vector3 = YinFuManager.Instance.endpoint.localPosition;
        GameUI.Instance.Add();
        transform.DOLocalMove(vector3, 10f).OnComplete(delegate ()
        {
            YinFuManager.Instance.DestroyYinFu(this);
        });

        //缩小逻辑
        transform.DOScale(Vector3.zero, 12f);

    }
}
