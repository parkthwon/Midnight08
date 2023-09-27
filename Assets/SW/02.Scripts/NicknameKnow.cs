using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameKnow : MonoBehaviour
{
    public Text nickname;

    // Start is called before the first frame update
    void Start()
    {
        CallName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CallName()
    {
        nickname.text = UIManager.instance.nickName;
    }
}
