using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnTextBlink : MonoBehaviour
{
    // 버튼 이미지
    public Text btnText;

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
        btnText.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnText.enabled = true;
        yield return new WaitForSeconds(0.1f);
        btnText.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnText.enabled = true;
        yield return new WaitForSeconds(0.1f);
        btnText.enabled = false;
        yield return new WaitForSeconds(0.1f);
        btnText.enabled = true;
    }
}
