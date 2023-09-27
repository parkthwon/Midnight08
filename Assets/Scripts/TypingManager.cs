using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    // �̱���
    public static TypingManager instance;
    private void Awake()
    {
        instance = this;
    }

    // Ÿ���� �ؽ�Ʈ ���
    public List<GameObject> typingList = new List<GameObject>();

    // Ÿ���� �� Ȯ��
    public bool isCoStop = false;

    // Ÿ���� Ƚ��
    public int count = 0;

    // ��ư next
    public Button btnNext;

    // �̹���
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
            //print("���� : " + typingList[count].name);
        }

        if (count == typingList.Count)
        {
            //print("Count" + typingList.Count);
            Image02.gameObject.SetActive(true);
            btnNext.gameObject.SetActive(true);
        }
    }
}
