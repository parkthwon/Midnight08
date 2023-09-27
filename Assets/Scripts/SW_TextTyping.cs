using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SW_TextTyping : MonoBehaviour
{
    // ≈ÿΩ∫∆Æ
    public Text text;

    [TextArea]
    public string inText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoTyping());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoTyping()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i <= inText.Length; i++)
        {
            text.text = inText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
