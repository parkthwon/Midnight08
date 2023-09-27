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
            // 시간이 변경되면 UI로 표현하고 싶다.
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
        // 시간이 지남에 따라 슬라이더의 값을 조금씩 더하고 싶다
        HP = hp + 0.2f * Time.deltaTime;

        if (sliderHP.value == maxHP)
        {
            print("dkdkdk");
            getMoneyImage.gameObject.SetActive(true);
        }
    }
}
