using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMove : MonoBehaviour
{
    public GameObject title;
    public Button btn;
    public InputField InputNickname;

    bool startBlink = false;

    float speed = 5f;
    Text btnText;
    Color textColor;

    // 첫번째 UI
    public GameObject UI1;
    public GameObject UI2;

    // Start is called before the first frame update
    void Start()
    {
        // 타이틀

        // BGM 시작~
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_01);
        // 처음 위치 저장
        Vector3 originPos = title.transform.position;
        // 타이틀의 위치를 화면 밖으로 이동
        RectTransform rt = title.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Screen.width, rt.anchoredPosition.y);

        // itween으로 화면 가운데에 나오게 하자
        iTween.MoveTo(title, iTween.Hash("delay", 1, "x", originPos.x, "easetype", iTween.EaseType.easeInOutBounce, "time", 0.5));

        // 닉네임 입력창
        InputNickname.transform.localScale = Vector3.zero;
        iTween.ScaleTo(InputNickname.gameObject, iTween.Hash("delay", 2f, "scale", Vector3.one, "easetype", iTween.EaseType.easeInOutBack, "time", 0.5));


        // 버튼
        btn.transform.localScale = Vector3.zero;
        iTween.ScaleTo(btn.gameObject, iTween.Hash("delay", 2, "scale", Vector3.one, "easetype", iTween.EaseType.easeInOutBack, "time", 0.5));

        // 버튼 텍스트 색 가져오기
        btnText = btn.GetComponentInChildren<Text>();
        textColor = btnText.color;
        // 버튼 비활성화
        btn.interactable = false;

        // inputField 의 내용이 변경될 때 호출될 함수
        InputNickname.onValueChanged.AddListener(OnValueChangedNickName);
    }

    void OnValueChangedNickName(string name)
    {
        btn.interactable = name.Length > 0;
        btnText.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (btn.interactable == false)
        {
            btnText.color = Color.gray;
            //print("false");
        }

        // 만약 버튼이 활성화 되었다면
        else if (InputNickname.text.Length > 0)
        {
            //print("true");
            //btn.interactable = true;
            //btnText.color = Color.black;

            // 버튼을 깜빡이게 한다
            if (startBlink)
            {
                textColor.a += Time.deltaTime * speed;
                if (textColor.a >= 1f)
                {
                    startBlink = false;
                }
            }
            else
            {
                textColor.a -= Time.deltaTime * speed;
                if (textColor.a <= -0.5f)
                {
                    startBlink = true;
                }
            }
            btnText.color = textColor;
        }
    }

    public void OnClickStartBtn()
    {
        // Start버튼을 누르면 호출되는 함수
        // 버튼을 누르면
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // 닉네임을 저장한다
        UIManager.instance.nickName = InputNickname.text;
        // 첫번째 UI 페이지를 비활성화 시킨다
        UI1.SetActive(false);
        UI2.SetActive(true);
        // 사운드 매니저에서 bgm을 바꾼다
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_02);
    }
}
