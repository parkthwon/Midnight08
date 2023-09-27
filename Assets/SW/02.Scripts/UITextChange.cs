using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextChange : MonoBehaviour
{
    public Text[] textToChange;
    int idx = 0;
    //public string newText = "New Text After Click";
    private void Start()
    {
        ChangeTextOnClick(this.idx);
    }

    public void OnChangeTextOnClick()
    {
        idx++;
        if(textToChange.Length <= idx)
        {
            idx = textToChange.Length - 1;
        }
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        ChangeTextOnClick(this.idx);
    }
    public void ChangeTextOnClick(int index)
    {
        for (int i = 0; i < textToChange.Length; i++)
        {
            textToChange[i].gameObject.SetActive(i == index);
        }
    }
}