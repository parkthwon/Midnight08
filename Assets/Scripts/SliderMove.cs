using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    float hp;
    public float maxHP = 2;
    public Slider sliderHP;

    public Button btnNextScene;
    public Image getMoneyImage;

    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;
            // �ð��� ����Ǹ� UI�� ǥ���ϰ� �ʹ�.
            sliderHP.value = hp;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        sliderHP.maxValue = maxHP;
        HP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� ������ ���� �����̴��� ���� ���ݾ� ���ϰ� �ʹ�
        HP = hp + 0.2f * Time.deltaTime;

        if (sliderHP.value == maxHP)
        {
            print("dkdkdk");
            getMoneyImage.gameObject.SetActive(true);
        }
    }
}
