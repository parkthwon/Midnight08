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

    // ù��° UI
    public GameObject UI1;
    public GameObject UI2;

    // Start is called before the first frame update
    void Start()
    {
        // Ÿ��Ʋ

        // BGM ����~
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_01);
        // ó�� ��ġ ����
        Vector3 originPos = title.transform.position;
        // Ÿ��Ʋ�� ��ġ�� ȭ�� ������ �̵�
        RectTransform rt = title.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(Screen.width, rt.anchoredPosition.y);

        // itween���� ȭ�� ����� ������ ����
        iTween.MoveTo(title, iTween.Hash("delay", 1, "x", originPos.x, "easetype", iTween.EaseType.easeInOutBounce, "time", 0.5));

        // �г��� �Է�â
        InputNickname.transform.localScale = Vector3.zero;
        iTween.ScaleTo(InputNickname.gameObject, iTween.Hash("delay", 2f, "scale", Vector3.one, "easetype", iTween.EaseType.easeInOutBack, "time", 0.5));


        // ��ư
        btn.transform.localScale = Vector3.zero;
        iTween.ScaleTo(btn.gameObject, iTween.Hash("delay", 2, "scale", Vector3.one, "easetype", iTween.EaseType.easeInOutBack, "time", 0.5));

        // ��ư �ؽ�Ʈ �� ��������
        btnText = btn.GetComponentInChildren<Text>();
        textColor = btnText.color;
        // ��ư ��Ȱ��ȭ
        btn.interactable = false;

        // inputField �� ������ ����� �� ȣ��� �Լ�
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

        // ���� ��ư�� Ȱ��ȭ �Ǿ��ٸ�
        else if (InputNickname.text.Length > 0)
        {
            //print("true");
            //btn.interactable = true;
            //btnText.color = Color.black;

            // ��ư�� �����̰� �Ѵ�
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
        // Start��ư�� ������ ȣ��Ǵ� �Լ�
        // ��ư�� ������
        // SFX Play
        SoundManager.instance.PlaySFX(SoundManager.ESfx.SFX_BUTTON);
        // �г����� �����Ѵ�
        UIManager.instance.nickName = InputNickname.text;
        // ù��° UI �������� ��Ȱ��ȭ ��Ų��
        UI1.SetActive(false);
        UI2.SetActive(true);
        // ���� �Ŵ������� bgm�� �ٲ۴�
        SoundManager.instance.PlayBGM(SoundManager.EBgm.BGM_02);
    }
}
