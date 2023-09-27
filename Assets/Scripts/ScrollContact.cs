using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollContact : MonoBehaviour
{
    // 목적지
    public Transform targetPos;

    // 스크롤할 계약서
    public GameObject contract;

    // 이동 속력
    public float speed = 30f;

    public GameObject btnNext;

    public BtnTextBlink bTB;

    // Start is called before the first frame update
    void Start()
    {
        Image btn = btnNext.GetComponent<Image>();
        btn.enabled = false;
        btnNext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //contact의 위치를 목적지 까지 러프한다
        if (Vector3.Distance(targetPos.position, contract.transform.position) > 1f)
        {
            contract.transform.position = Vector3.Lerp(contract.transform.position, targetPos.position, speed * Time.deltaTime);
            bTB.enabled = true;
            print("러프함");
        }
    }

    
}
