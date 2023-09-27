using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // �̱���
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // BGM
    public enum EBgm
    {
        BGM_01,
        BGM_02,
        BGM_03,
        BGM_04,
    }

    // SFX
    public enum ESfx
    {
        SFX_BUTTON,
    }

    // BGM �迭
    public AudioClip[] bgms;
    // SFX �迭
    public AudioClip[] sfxs;

    //
    public AudioSource audioBgm;
    public AudioSource audioSfx;


    // BGM Play
    public void PlayBGM(EBgm bgmIdx)
    {
        // �÷����� BGM ����
        audioBgm.clip = bgms[(int)bgmIdx];
        audioBgm.Play();
    }

    // Bgm ����
    // connection bgm ���� (�ڿ� �̸� �ٲٱ�)
    //SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_CONNECTION);

    public void StopBGM()
    {
        audioBgm.Stop();
    }

    // SFX Play
    public void PlaySFX(ESfx sfxIdx)
    {
        // ������ �ʰ� ������ �÷���
        audioSfx.PlayOneShot(sfxs[(int)sfxIdx]);
    }

    // ���콺 Ŭ�� �� ������ �� �ڵ�
    // SFX Play
    //SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
}
