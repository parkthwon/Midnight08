using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickNamePrint : MonoBehaviour
{
    // 닉네임
    public Text textNickName;
    
    // Start is called before the first frame update
    void Start()
    {
        textNickName.text = "서명 : " + UIManager.instance.nickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
