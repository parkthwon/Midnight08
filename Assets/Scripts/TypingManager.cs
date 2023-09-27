using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    // 싱글톤
    public static TypingManager instance;
    private void Awake()
    {
        instance = this;
    }

    // 타이핑 텍스트 목록
    public List<GameObject> typingList = new List<GameObject>();

    // 타이핑 끝 확인
    public bool isCoStop = false;

    // 타이핑 횟수
    public int count = 0;

    // 버튼 next
    public Button btnNext;

    // 이미지
    public Image Image02;

    // Start is called before the first frame update
    void Start()
    {
        typingList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCoStop && count < typingList.Count)
        {
            isCoStop = false;
            typingList[count].SetActive(true);
            //print("끝남 : " + typingList[count].name);
        }

        if (count == typingList.Count)
        {
            //print("Count" + typingList.Count);
            Image02.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
        }
    }
}
