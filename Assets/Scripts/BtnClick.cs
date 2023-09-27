using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour
{
    // ScrollContact
    public ScrollContact scrollContact;

    public GameObject UI02;
    public GameObject UI03;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("Midnight_PSW");
        }
    }

    // 클릭하면 contact의 위치를 목적지 까지 러프하는 ScrollContact 스크립트를 활성화 시킨다
    public void OnClickBtnNext()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        scrollContact.enabled = true;
        print("BtnNext 클릭");
    }

    public void OnClickBtnAgree()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // UI02 비활성화
        UI02.SetActive(false);
        UI03.SetActive(true);
        // 사운드 매니저에서 bgm을 바꾼다
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_04);
    }

    public void OnClickBtnNextScene()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // 씬 넘기기
        print("다음 씬으로");
        SceneManager.LoadScene("1. MainScene");
        // 사운드 매니저에서 bgm을 바꾼다
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_02);
    }

    
}
