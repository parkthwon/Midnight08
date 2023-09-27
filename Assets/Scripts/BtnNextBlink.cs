using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnNextBlink : MonoBehaviour
{
    // 버튼 이미지
    public Image btnImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoBtnBlink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoBtnBlink()
    {
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = true;
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = true;
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnImage.enabled = true;
        print("corujj");
    }
}
