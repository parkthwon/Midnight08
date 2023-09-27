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

    // Ŭ���ϸ� contact�� ��ġ�� ������ ���� �����ϴ� ScrollContact ��ũ��Ʈ�� Ȱ��ȭ ��Ų��
    public void OnClickBtnNext()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        scrollContact.enabled = true;
        print("BtnNext Ŭ��");
    }

    public void OnClickBtnAgree()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // UI02 ��Ȱ��ȭ
        UI02.SetActive(false);
        UI03.SetActive(true);
        // ���� �Ŵ������� bgm�� �ٲ۴�
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_04);
    }

    public void OnClickBtnNextScene()
    {
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // �� �ѱ��
        print("���� ������");
        SceneManager.LoadScene("1. MainScene");
        // ���� �Ŵ������� bgm�� �ٲ۴�
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_02);
    }

    
}
