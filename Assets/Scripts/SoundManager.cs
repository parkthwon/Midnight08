using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // 싱글톤
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

    // BGM 배열
    public AudioClip[] bgms;
    // SFX 배열
    public AudioClip[] sfxs;

    //
    public AudioSource audioBgm;
    public AudioSource audioSfx;


    // BGM Play
    public void PlayBGM(EBgm bgmIdx)
    {
        // 플레이할 BGM 셋팅
        audioBgm.clip = bgms[(int)bgmIdx];
        audioBgm.Play();
    }

    // Bgm 실행
    // connection bgm 실행 (뒤에 이름 바꾸기)
    //SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_CONNECTION);

    public void StopBGM()
    {
        audioBgm.Stop();
    }

    // SFX Play
    public void PlaySFX(ESfx sfxIdx)
    {
        // 끊기지 않고 끝까지 플레이
        audioSfx.PlayOneShot(sfxs[(int)sfxIdx]);
    }

    // 마우스 클릭 할 곳에서 쓸 코드
    // SFX Play
    //SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
}
