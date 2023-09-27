using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBtnHopeScene()
    {
        // æ¿ ≥—±‚±‚
        print("¥Ÿ¿Ω æ¿¿∏∑Œ");
        SceneManager.LoadScene("Midnight_PSW");
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_03);
    }
}
