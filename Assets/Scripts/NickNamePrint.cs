using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickNamePrint : MonoBehaviour
{
    // �г���
    public Text textNickName;
    
    // Start is called before the first frame update
    void Start()
    {
        textNickName.text = "���� : " + UIManager.instance.nickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
